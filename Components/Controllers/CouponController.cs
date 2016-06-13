using DotNetNuke.Data;
using System.Collections.Generic;
using System.Linq;
using Ventrian.Modules.Subscriptions.Components.Entities;

namespace Ventrian.Modules.Subscriptions.Components.Controllers
{
    public class CouponController
    {
        public int AddCoupon(Coupon objCoupon)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Coupon>();
                rep.Insert(objCoupon);
            }

            return objCoupon.CouponID;
        }

        public void DeleteCoupon(Coupon objCoupon)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Coupon>();
                objCoupon.IsDeleted = true;
                rep.Update(objCoupon);
            }
        }

        public Coupon GetCoupon(int CouponID, int moduleID)
        {
            Coupon Coupon;

            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Coupon>();
                Coupon = rep.GetById(CouponID, moduleID);
            }

            return Coupon;
        }

        public IEnumerable<Coupon> GetCoupons(int moduleID)
        {
            IEnumerable<Coupon> Coupons;

            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Coupon>();
                Coupons = rep.Get(moduleID);
            }

            return Coupons.Where(p => !p.IsDeleted);
        }

        public void UpdateCoupon(Coupon objCoupon)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Coupon>();
                rep.Update(objCoupon);
            }
        }
    }
}