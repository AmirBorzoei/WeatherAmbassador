using System.Linq;
using WeatherAmbassador.Persistence.EF.Models;
using WeatherAmbassador.Services.Contracts;

namespace WeatherAmbassador.Persistence.EF.Repositories
{
    public class SettingWriter : ISettingWriter
    {
        private readonly ISettingReader settingReader;

        public SettingWriter(ISettingReader settingReader)
        {
            this.settingReader = settingReader;
        }

        public void InsertOrUpdate(string settingKey, string settingValue)
        {
            using var weatherDbContext = new WeatherDbContext();
            var oldSetting = weatherDbContext.Settings.SingleOrDefault(s => s.SettingKey.Equals(settingKey));
            if (oldSetting == null)
            {
                var newSetting = new Setting { SettingKey = settingKey, SettingValue = settingValue };
                weatherDbContext.Settings.Add(newSetting);
            }
            else
            {
                oldSetting.SettingValue = settingValue;
            }

            weatherDbContext.SaveChanges();

            settingReader.ClearCachedData();
        }
    }
}