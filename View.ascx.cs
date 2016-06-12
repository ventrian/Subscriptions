using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Security;
using System;
using Ventrian.Modules.Subscriptions.Base;
using Ventrian.Modules.Subscriptions.Components.Entities;

namespace Ventrian.Modules.Subscriptions
{
    public partial class View : SubscriptionBase<SubscriptionSettings>, IActionable
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #region Interface Methods

        public ModuleActionCollection ModuleActions
        {
            get
            {
                var actions = new ModuleActionCollection
                    {
                        {
                            GetNextActionID(), LocalizeString("EditCoupons"), "", "", "",
                                EditUrl("EditCoupons"), false, SecurityAccessLevel.Edit, true, false
                        },
                        {
                            GetNextActionID(), LocalizeString("EditPlans"), "", "", "",
                                EditUrl("EditPlans"), false, SecurityAccessLevel.Edit, true, false
                        }
                    };
                return actions;
            }
        }

        #endregion
    }
}