using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Settings;
using System.Collections.Generic;
using Ventrian.Modules.Subscriptions.Components.Controllers;
using Ventrian.Modules.Subscriptions.Components.Entities;

namespace Ventrian.Modules.Subscriptions.Base
{
    public class SubscriptionBase<TModuleSettings> : PortalModuleBase
            where TModuleSettings : class, new()
    {
        #region Settings Overrides 

        protected class SubscriptionSettingsRepository : SettingsRepository<TModuleSettings> { }
        private SubscriptionSettingsRepository SettingsRepository { get; } = new SubscriptionSettingsRepository();
        public new TModuleSettings Settings => SettingsRepository.GetSettings(ModuleConfiguration);

        #endregion

        #region Protected Properties

        protected IEnumerable<Plan> Plans
        {
            get
            {
                var objPlanController = new PlanController();
                return objPlanController.GetPlans(ModuleId);
            }
        }

        #endregion
    }


}