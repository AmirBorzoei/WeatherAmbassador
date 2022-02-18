using System;
using System.Net.Http;
using Polly;
using Polly.Wrap;
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

            var policies = GetApiCallPolicies();
            var httpClient = httpClientFactory.CreateClient();
            var apiResponse = policies.ExecuteAsync(() => httpClient.GetStringAsync(uri));
            return apiResponse.Result;
        }

        private AsyncPolicyWrap<string> GetApiCallPolicies()
        {
            var retryPolicy = Policy<string>.Handle<Exception>().RetryAsync(3);
            var circuitBreakerPolicy = Policy.Handle<Exception>().CircuitBreakerAsync(2, TimeSpan.FromMilliseconds(1000));
            var policies = retryPolicy.WrapAsync(circuitBreakerPolicy);
            return policies;
        }
    }
}