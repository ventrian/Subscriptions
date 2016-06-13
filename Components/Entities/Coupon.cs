using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using System;
using System.Web.Caching;
using Ventrian.Modules.Subscriptions.Components.Types;

namespace Ventrian.Modules.Subscriptions.Components.Entities
{
    [TableName("Ventrian_Subscriptions_Coupon")]
    [PrimaryKey("CouponID", AutoIncrement = true)]
    [Scope("ModuleID")]
    [Cacheable("Coupons", CacheItemPriority.Default, 20)]
    public class Coupon
    {
        public int CouponID { get; set; }
        public int ModuleID { get; set; }
        public string Code { get; set; }
        public DiscountType DiscountType { get; set; } = DiscountType.Percentage;
        public int Amount { get; set; }
        public int? Quantity { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
    }
}