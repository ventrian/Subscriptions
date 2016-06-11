using DotNetNuke.ComponentModel.DataAnnotations;
using Ventrian.Modules.Subscriptions.Components.Types;

namespace Ventrian.Modules.Subscriptions.Components.Entities
{
    [TableName("Ventrian_Subscriptions_Plan")]
    [PrimaryKey("PlanID", AutoIncrement = true)]
    public class Plan
    {
        public int PlanID { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }
        public int ViewOrder { get; set; }

        public decimal ServiceFee { get; set; }

        public bool AutoRecurring { get; set; }
        public FrequencyType BillingFrequency { get; set; }
        public int BillingPeriod { get; set; }
    }
}