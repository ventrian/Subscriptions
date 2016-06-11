using DotNetNuke.Entities.Modules;
using DotNetNuke.Framework;
using DotNetNuke.Security.Permissions;
using System.Collections.Generic;
using Ventrian.Modules.Subscriptions.Components.Controllers;
using Ventrian.Modules.Subscriptions.Components.Entities;

namespace Ventrian.Modules.Subscriptions.Base
{
    public class SubscriptionBase : PortalModuleBase
    {
        #region Private Members

        private SubscriptionSetting _subscriptionSetting;

        #endregion

        #region Protected Properties

        protected bool CanEditModule
        {
            get
            {
                if (UserInfo.IsSuperUser)
                    return true;

                return ModulePermissionController.CanEditModuleContent(ModuleConfiguration);
            }
        }

        protected CDefault PageBase
        {
            get { return (CDefault)Page; }
        }

        protected IEnumerable<Plan> Plans
        {
            get
            {
                var objPlanController = new PlanController();
                return objPlanController.GetPlans(ModuleId);
            }
        }

        protected SubscriptionSetting SubscriptionSettings
        {
            get { return _subscriptionSetting ?? (_subscriptionSetting = new SubscriptionSetting(Settings)); }
        }

        #endregion
    }
}