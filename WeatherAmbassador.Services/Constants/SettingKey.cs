using System.Collections.Generic;

namespace WeatherAmbassador.Services.Constants
{
    public class SettingKey
    {
        public static List<string> AllSettingKeys = new() { WeatherApiUrl, WeatherApiCallIntervalFormat };
        
        public static string WeatherApiUrl = "WeatherApiUrl";
        public static string WeatherApiCallIntervalFormat = "WeatherApiCallIntervalFormat";
    }
}