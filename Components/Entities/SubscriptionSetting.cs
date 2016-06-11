using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ventrian.Modules.Subscriptions.Components.Common;

namespace Ventrian.Modules.Subscriptions.Components.Entities
{
    public class SubscriptionSetting
    {
        #region Private Members

        private readonly Hashtable _settings;

        #endregion

        #region Constructors

        public SubscriptionSetting(Hashtable settings)
        {
            _settings = settings;
        }

        #endregion

        #region Public Properties
        
        public string Template
        {
            get
            {
                return _settings.Contains(Constants.SettingTemplate) ?
                    _settings[Constants.SettingTemplate].ToString() :
                    Constants.SettingTemplateDefault;
            }
        }
        
        #endregion
    }
}