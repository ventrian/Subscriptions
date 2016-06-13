using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using System.Web.Caching;
using Ventrian.Modules.Subscriptions.Components.Types;

namespace Ventrian.Modules.Subscriptions.Components.Entities
{
    [TableName("Ventrian_Subscriptions_Plan")]
    [PrimaryKey("PlanID", AutoIncrement = true)]
    [Scope("ModuleID")]
    [Cacheable("Plans", CacheItemPriority.Default, 20)]
    public class Plan
    {
        public int PlanID { get; set; } = Null.NullInteger;
        public int ModuleID { get; set; } = Null.NullInteger;
        public int RoleID { get; set; } = Null.NullInteger;

        public string Name { get; set; } = "";
        public int ViewOrder { get; set; } = 0;

        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        public decimal ServiceFee { get; set; } = 0;
        public bool AutoRecurring { get; set; } = false;
        public FrequencyType BillingFrequency { get; set; } = FrequencyType.OneTimeFee;
        public int BillingPeriod { get; set; } = Null.NullInteger;

        // Helpers
        [IgnoreColumn]
        public string BillingDescription
        {
            get
            {
                var description = "";
                switch (BillingFrequency)
                {
                    case FrequencyType.OneTimeFee:
                        description = ServiceFee.ToString("C") + " as a one time fee";
                        break;
                    default:
                        description = ServiceFee.ToString("C") + " is billed every " + BillingPeriod + " " + BillingFrequency.ToString() + "(s)";
                        if (AutoRecurring)
                            description += " (Auto-Renews)";
                        break; 
                }
                return description;
            }
        }
    }
}