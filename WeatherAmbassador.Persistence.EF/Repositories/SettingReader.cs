using System;
using System.Collections.Generic;
using System.Linq;
using WeatherAmbassador.Services.Contracts;

namespace WeatherAmbassador.Persistence.EF.Repositories
{
    public class SettingReader : ISettingReader
    {
        private Dictionary<string, string> settings;

        public SettingReader()
        {
            LoadSettings();
        }

        public Dictionary<string, string> GetAllSettings()
        {
            return settings;
        }

        public string GetSettingValue(string settingKey)
        {
            if (settings == null)
            {
                LoadSettings();
            }

            if (!settings.ContainsKey(settingKey))
            {
                throw new Exception("Invalid Setting Key!");
            }

            return settings[settingKey];
        }

        public void ClearCachedData()
        {
            settings = null;
        }

        private void LoadSettings()
        {
            using var weatherDbContext = new WeatherDbContext();
            settings = weatherDbContext.Settings.ToDictionary(s => s.SettingKey, s => s.SettingValue);
        }
    }
}