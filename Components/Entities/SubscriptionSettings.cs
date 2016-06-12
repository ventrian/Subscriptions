using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Settings;

namespace Ventrian.Modules.Subscriptions.Components.Entities
{
    public class SubscriptionSettings
    {
        private const string SettingPrefix = "Ventrian_Subscriptions_";

        [ModuleSetting(Prefix = SettingPrefix)]
        public string Template { get; set; } = "";

        public static SubscriptionSettings Load(ModuleInfo module)
        {
            var repository = new SubscriptionSettingsRepository();
            return repository.GetSettings(module);
        }

        public void Save(ModuleInfo module)
        {
            var repository = new SubscriptionSettingsRepository();
            repository.SaveSettings(module, this);
        } 
    }

    public class SubscriptionSettingsRepository : SettingsRepository<SubscriptionSettings> {}
}