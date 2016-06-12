using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using Ventrian.Modules.Subscriptions.Components.Types;

namespace Ventrian.Modules.Subscriptions.Components.Entities
{
    [TableName("Ventrian_Subscriptions_Plan")]
    [PrimaryKey("PlanID", AutoIncrement = true)]
    public class Plan
    {
        public int PlanID { get; set; } = Null.NullInteger;
        public int ModuleID { get; set; } = Null.NullInteger;
        public int RoleID { get; set; } = Null.NullInteger;

        public string Name { get; set; } = "";
        public int ViewOrder { get; set; } = 0;

        public bool Deleted { get; set; } = false;

        public decimal ServiceFee { get; set; } = 0;
        public bool AutoRecurring { get; set; } = false;
        public FrequencyType BillingFrequency { get; set; } = FrequencyType.OneTimeFee;
        public int BillingPeriod { get; set; } = Null.NullInteger;

        // Helpers
        [IgnoreColumn]
        public string BillingPeriodDescription
        {
            get
            {
                if (BillingPeriod == Null.NullInteger) return "N/A";
                return BillingPeriod.ToString();
            }
        }
    }
}