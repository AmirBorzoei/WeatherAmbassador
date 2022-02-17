using System.Collections.Generic;

namespace WeatherAmbassador.Services.Constants
{
    public class SettingKey
    {
        public static string WeatherApiUrl = "WeatherApiUrl";
        public static string WeatherApiCallIntervalFormat = "WeatherApiCallIntervalFormat";

        public static List<string> AllSettingKeys = new() { WeatherApiUrl, WeatherApiCallIntervalFormat };
    }
}