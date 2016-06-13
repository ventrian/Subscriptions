using DotNetNuke.Services.Exceptions;
using System;
using Ventrian.Modules.Subscriptions.Base;
using Ventrian.Modules.Subscriptions.Components.Entities;

namespace Ventrian.Modules.Subscriptions
{
    public partial class EditCoupons : SubscriptionBase<SubscriptionSettings>
    {
        #region Private Methods

        private void BindCoupons()
        {
            grdCoupons.DataSource = Coupons;
            grdCoupons.DataBind();

            if (grdCoupons.Items.Count == 0)
            {
                grdCoupons.Visible = false;
                phNoCoupons.Visible = true;
            }
        }

        #endregion

        #region Protected Methods

        protected string GetEditUrl(int planID)
        {
            return EditUrl("cid", planID.ToString(), "EditCoupon");
        }

        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                BindCoupons();
                lnkAddEntry.NavigateUrl = EditUrl("EditCoupon");
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

        #endregion
    }
}