using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using System;
using Ventrian.Modules.Subscriptions.Components.Entities;

namespace Ventrian.Modules.Subscriptions
{
    public partial class Settings : ModuleSettingsBase
    {
        #region Private Members

        private SubscriptionSettings _settings;

        #endregion

        #region Private Properties 

        private new SubscriptionSettings ModuleSettings
        {
            get
            {
                if (_settings == null)
                    _settings = SubscriptionSettings.Load(ModuleConfiguration);
                return _settings;
            }
            set { _settings = value; }
        }

        #endregion

        #region Base Method Implementations

        public override void LoadSettings()
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    txtTemplate.Text = ModuleSettings.Template;
                }
            }
            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        public override void UpdateSettings()
        {
            try
            {
                ModuleSettings.Template = txtTemplate.Text;
                ModuleSettings.Save(ModuleConfiguration);
            }
            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        #endregion
    }
}