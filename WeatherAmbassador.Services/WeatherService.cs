using System;
using System.Threading.Tasks;
using WeatherAmbassador.Services.Constants;
using WeatherAmbassador.Services.Contracts;

namespace WeatherAmbassador.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly ISettingReader settingReader;
        private readonly IWeatherProxy weatherProxy;
        private readonly IWeatherRepository weatherRepository;

        public WeatherService(IWeatherProxy weatherProxy,
                IWeatherRepository weatherRepository,
                ISettingReader settingReader)
        {
            this.weatherProxy = weatherProxy;
            this.weatherRepository = weatherRepository;
            this.settingReader = settingReader;
        }

        public string GetWeatherInfo()
        {
            var apiCallKey = GenerateApiCallKey();

            var currentApiCallResult = GetCurrentApiCallResult(apiCallKey);
            if (currentApiCallResult != null)
            {
                return currentApiCallResult;
            }

            return GetWeatherInfoFromProxyOrRepository(apiCallKey);
        }
        
        private string GenerateApiCallKey()
        {
            var apiCallIntervalFormat = settingReader.GetSettingValue(SettingKey.WeatherApiCallIntervalFormat);
            var apiCallKey = DateTime.Now.ToString(apiCallIntervalFormat);
            return apiCallKey;
        }

        private string GetCurrentApiCallResult(string apiCallKey)
        {
            var currentApiCallResult = weatherRepository.GetApiCallResult(apiCallKey);
            return currentApiCallResult;
        }

        private string GetWeatherInfoFromProxyOrRepository(string apiCallKey)
        {
            try
            {
                var newApiCallResult = weatherProxy.CallApi();
                SaveWeatherLog(apiCallKey, newApiCallResult);
                return newApiCallResult;
            }
            catch
            {
                return GetLatestWeatherLog();
            }
        }

        private void SaveWeatherLog(string apiCallKey, string apiCallResult)
        {
            Task.Factory.StartNew(() =>
                {
                    weatherRepository.AddLatestWeatherLog(apiCallKey, apiCallResult);
                });
        }

        private string GetLatestWeatherLog()
        {
            return weatherRepository.GetLatestWeatherLog();
        }
    }
}