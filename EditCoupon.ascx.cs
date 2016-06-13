using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Exceptions;
using System;
using System.Web.UI.WebControls;
using Ventrian.Modules.Subscriptions.Base;
using Ventrian.Modules.Subscriptions.Components.Controllers;
using Ventrian.Modules.Subscriptions.Components.Entities;
using Ventrian.Modules.Subscriptions.Components.Types;

namespace Ventrian.Modules.Subscriptions
{
    public partial class EditCoupon : SubscriptionBase<SubscriptionSettings>
    {
        #region Private Properties

        private int CouponID
        {
            get
            {
                int couponID;
                if (!Int32.TryParse(Page.Request["cid"], out couponID))
                    couponID = Null.NullInteger;

                return couponID;
            }
        }

        #endregion

        #region Private Methods 

        private void BindDiscountType()
        {
            foreach (int value in Enum.GetValues(typeof(DiscountType)))
            {
                var li = new ListItem()
                {
                    Value = value.ToString(),
                    Text = LocalizeString(Enum.GetName(typeof(DiscountType), value))
                };
                lstDiscountType.Items.Add(li);
            }

            if (lstDiscountType.Items.Count > 0)
                lstDiscountType.Items[0].Selected = true;
        }

        private void BindCoupon()
        {
            if (CouponID != Null.NullInteger)
            {
                var objCouponController = new CouponController();
                var objCoupon = objCouponController.GetCoupon(CouponID, ModuleId);

                if (objCoupon == null)
                {
                    Response.Redirect(EditUrl("EditCoupons"));
                }
                else
                {
                    txtCode.Text = objCoupon.Code;
                    if (lstDiscountType.Items.FindByValue(objCoupon.DiscountType.ToString()) != null)
                        lstDiscountType.SelectedValue = objCoupon.DiscountType.ToString();
                    txtAmount.Text = objCoupon.Amount.ToString();
                    txtQuantity.Text = objCoupon.Quantity.ToString();
                    txtStartDate.SelectedDate = objCoupon.StartDate;
                    txtEndDate.SelectedDate = objCoupon.EndDate;
                    chkIsActive.Checked = objCoupon.IsActive;

                    // Allow users to delete coupon
                    cmdDelete.Visible = true;
                }
            }
        }

        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindDiscountType();

                    BindCoupon();

                    lnkCancel.NavigateUrl = EditUrl("EditCoupons");
                    txtCode.Focus();
                }
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

        protected void OnSaveClick(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (CouponID != Null.NullInteger)
                    {
                        // Update Coupon
                        var objCouponController = new CouponController();
                        var objCoupon = objCouponController.GetCoupon(CouponID, ModuleId);

                        if (objCoupon != null)
                        {
                            objCoupon.ModuleID = ModuleId;
                            objCoupon.Code = txtCode.Text;
                            objCoupon.DiscountType = (DiscountType)Enum.Parse(typeof(DiscountType), lstDiscountType.SelectedValue);

                            Int32 amount;
                            if (!Int32.TryParse(txtAmount.Text, out amount))
                                amount = 0;
                            if (amount < 0)
                                amount = 0;
                            objCoupon.Amount = amount;

                            Int32 quantity;
                            if (Int32.TryParse(txtQuantity.Text, out quantity))
                            {
                                if (quantity > 0)
                                    objCoupon.Quantity = quantity;
                            }
                            objCoupon.Quantity = null;

                            if( txtStartDate.SelectedDate.HasValue )
                                objCoupon.StartDate = txtStartDate.SelectedDate.Value;

                            if (txtEndDate.SelectedDate.HasValue)
                                objCoupon.EndDate = txtEndDate.SelectedDate.Value;

                            objCoupon.IsActive = chkIsActive.Checked;

                            objCouponController.UpdateCoupon(objCoupon);
                        }
                    }
                    else
                    {
                        // Add Coupon
                        var objCoupon = new Coupon();

                        objCoupon.ModuleID = ModuleId;
                        objCoupon.Code = txtCode.Text;
                        objCoupon.DiscountType = (DiscountType)Enum.Parse(typeof(DiscountType), lstDiscountType.SelectedValue);

                        Int32 amount;
                        if (!Int32.TryParse(txtAmount.Text, out amount))
                            amount = 0;
                        if (amount < 0)
                            amount = 0;
                        objCoupon.Amount = amount;

                        Int32 quantity;
                        if (Int32.TryParse(txtQuantity.Text, out quantity))
                        {
                            if (quantity > 0)
                                objCoupon.Quantity = quantity;
                        }

                        if (txtStartDate.SelectedDate.HasValue)
                            objCoupon.StartDate = txtStartDate.SelectedDate.Value;

                        if (txtEndDate.SelectedDate.HasValue)
                            objCoupon.EndDate = txtEndDate.SelectedDate.Value;

                        objCoupon.IsActive = chkIsActive.Checked;

                        var objCouponController = new CouponController();
                        objCouponController.AddCoupon(objCoupon);
                    }

                    Response.Redirect(EditUrl("EditCoupons"));
                }
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

        protected void OnDeleteClick(object sender, EventArgs e)
        {
            try
            {

                if (CouponID != Null.NullInteger)
                {
                    // Update Coupon
                    var objCouponController = new CouponController();
                    var objCoupon = objCouponController.GetCoupon(CouponID, ModuleId);

                    if (objCoupon != null)
                        objCouponController.DeleteCoupon(objCoupon);
                }

                Response.Redirect(EditUrl("EditCoupons"));
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

        #endregion
    }
}