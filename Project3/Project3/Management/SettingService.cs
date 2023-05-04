using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Project3.Management
{
    public class SettingsService : ISettingsService
    {
        public ISettings AppSettings
        {
            get
            {
                try
                {
                    return CrossSettings.Current;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string MyGameTile
        {
            get { return AppSettings.GetValueOrDefault(MyGameTile, ""); }
            set { AppSettings.AddOrUpdateValue(nameof(MyGameTile), value); }
        }
    }
}
