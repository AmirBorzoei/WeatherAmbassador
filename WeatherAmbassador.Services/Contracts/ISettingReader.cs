using System.Collections.Generic;

namespace WeatherAmbassador.Services.Contracts
{
    public interface ISettingReader
    {
        Dictionary<string, string> GetAllSettings();

        string GetSettingValue(string settingKey);

        void ClearCachedData();
    }
}