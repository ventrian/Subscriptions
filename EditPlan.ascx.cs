using DotNetNuke.Common.Utilities;
using DotNetNuke.Security.Roles;
using DotNetNuke.Services.Exceptions;
using System;
using System.Web.UI.WebControls;
using Ventrian.Modules.Subscriptions.Base;
using Ventrian.Modules.Subscriptions.Components.Controllers;
using Ventrian.Modules.Subscriptions.Components.Entities;
using Ventrian.Modules.Subscriptions.Components.Types;

namespace Ventrian.Modules.Subscriptions
{
    public partial class EditPlan : SubscriptionBase<SubscriptionSettings>
    {
        #region Private Properties

        private int PlanID
        {
            get
            {
                int planID;
                if (!Int32.TryParse(Page.Request["pid"], out planID))
                    planID = Null.NullInteger;

                return planID;
            }
        }

        #endregion

        #region Private Methods 

        private void AdjustControlVisibility()
        {
            divBillingPeriod.Visible = !(lstBillingFrequency.SelectedValue == ((int)FrequencyType.OneTimeFee).ToString());
            divAutoRecurring.Visible = !(lstBillingFrequency.SelectedValue == ((int)FrequencyType.OneTimeFee).ToString());
        }

        private void BindFrequency()
        {
            foreach(int value in Enum.GetValues(typeof(FrequencyType)))
            {
                var li = new ListItem()
                {
                    Value = value.ToString(),
                    Text = LocalizeString(Enum.GetName(typeof(FrequencyType), value))
                };
                lstBillingFrequency.Items.Add(li);
            }

            if (lstBillingFrequency.Items.Count > 0)
                lstBillingFrequency.Items[0].Selected = true;
        }

        private void BindPeriod()
        {
            for(int i = 1; i <= 100; i++)
                lstBillingPeriod.Items.Add(i.ToString());
            lstBillingPeriod.Items.Insert(0, new ListItem(LocalizeString("SelectPeriod"), "-1"));
        }

        private void BindPlan()
        {
            if (PlanID != Null.NullInteger)
            {
                var objPlanController = new PlanController();
                var objPlan = objPlanController.GetPlan(PlanID, ModuleId);

                if (objPlan == null)
                {
                    Response.Redirect(EditUrl("EditPlans"));
                }
                else
                {
                    txtName.Text = objPlan.Name;
                    if (lstRoles.Items.FindByValue(objPlan.RoleID.ToString()) != null)
                        lstRoles.SelectedValue = objPlan.RoleID.ToString();
                    txtServiceFee.Text = objPlan.ServiceFee.ToString();
                    if (lstBillingFrequency.Items.FindByValue(objPlan.BillingFrequency.ToString()) != null)
                        lstBillingFrequency.SelectedValue = objPlan.BillingFrequency.ToString();
                    if (lstBillingPeriod.Items.FindByValue(objPlan.BillingPeriod.ToString()) != null)
                        lstBillingPeriod.SelectedValue = objPlan.BillingPeriod.ToString();
                    chkAutoRecurring.Checked = objPlan.AutoRecurring;
                    chkIsActive.Checked = objPlan.IsActive;

                    AdjustControlVisibility();

                    // Allow users to delete plan
                    cmdDelete.Visible = true;
                }
            }
            else
            {
                AdjustControlVisibility();
            }
        }

        private void BindRoles()
        {
            var objRoleController = new RoleController();

            lstRoles.DataSource = objRoleController.GetRoles(PortalId);
            lstRoles.DataBind();
            lstRoles.Items.Insert(0, new ListItem(LocalizeString("SelectRole"), Null.NullInteger.ToString()));
        }

        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if( !IsPostBack )
                {
                    BindFrequency();
                    BindPeriod();
                    BindRoles();

                    BindPlan();

                    lnkCancel.NavigateUrl = EditUrl("EditPlans");
                    txtName.Focus();
                }
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

        protected void lstBillingFrequency_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AdjustControlVisibility();
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
                if( Page.IsValid )
                {
                    if (PlanID != Null.NullInteger)
                    {
                        // Update Plan
                        var objPlanController = new PlanController();
                        var objPlan = objPlanController.GetPlan(PlanID, ModuleId);

                        if( objPlan != null )
                        {
                            objPlan.ModuleID = ModuleId;
                            objPlan.Name = txtName.Text;
                            objPlan.RoleID = Convert.ToInt32(lstRoles.SelectedValue);
                            decimal serviceFee;
                            if (!Decimal.TryParse(txtServiceFee.Text, out serviceFee))
                                serviceFee = 0;
                            objPlan.ServiceFee = serviceFee;
                            objPlan.BillingFrequency = (FrequencyType) Enum.Parse(typeof(FrequencyType), lstBillingFrequency.SelectedValue);
                            objPlan.BillingPeriod = Convert.ToInt32(lstBillingPeriod.SelectedValue);
                            objPlan.AutoRecurring = chkAutoRecurring.Checked;
                            objPlan.IsActive = chkIsActive.Checked;

                            objPlanController.UpdatePlan(objPlan);
                        }
                    }
                    else
                    {
                        // Add Plan
                        var objPlan = new Plan();

                        objPlan.ModuleID = ModuleId;
                        objPlan.Name = txtName.Text;
                        objPlan.RoleID = Convert.ToInt32(lstRoles.SelectedValue);
                        decimal serviceFee;
                        if (!Decimal.TryParse(txtServiceFee.Text, out serviceFee))
                            serviceFee = 0;
                        objPlan.ServiceFee = serviceFee;
                        objPlan.BillingFrequency = (FrequencyType)Enum.Parse(typeof(FrequencyType), lstBillingFrequency.SelectedValue);
                        objPlan.BillingPeriod = Convert.ToInt32(lstBillingPeriod.SelectedValue);
                        objPlan.AutoRecurring = chkAutoRecurring.Checked;
                        objPlan.IsActive = chkIsActive.Checked;

                        var objPlanController = new PlanController();
                        objPlanController.AddPlan(objPlan);
                    }

                    Response.Redirect(EditUrl("EditPlans"));
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

                if (PlanID != Null.NullInteger)
                {
                    // Update Plan
                    var objPlanController = new PlanController();
                    var objPlan = objPlanController.GetPlan(PlanID, ModuleId);

                    if (objPlan != null)
                        objPlanController.DeletePlan(objPlan);
                }

                Response.Redirect(EditUrl("EditPlans"));
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

        #endregion
    }
}