using System;
using System.Net.Http;
using WeatherAmbassador.Services.Constants;
using WeatherAmbassador.Services.Contracts;

namespace WeatherAmbassador.Proxies
{
    public class WeatherProxy : IWeatherProxy
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ISettingReader settingReader;

        public WeatherProxy(IHttpClientFactory httpClientFactory, ISettingReader settingReader)
        {
            this.httpClientFactory = httpClientFactory;
            this.settingReader = settingReader;
        }

        public string CallApi()
        {
            var weatherApiUrl = settingReader.GetSettingValue(SettingKey.WeatherApiUrl);
            var uri = new Uri(weatherApiUrl);

            var c = httpClientFactory.CreateClient();
            c.Timeout = TimeSpan.FromSeconds(5);
            var res = c.GetStringAsync(uri);

            var r = res.Result;

            return r;
        }
    }
}