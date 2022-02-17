using WeatherAmbassador.Services.Contracts;

namespace WeatherAmbassador.Services
{
    public class WeatherService: IWeatherService
    {
        private readonly IWeatherProxy weatherProxy;
        private readonly IWeatherRepository weatherRepository;

        public WeatherService(IWeatherProxy weatherProxy, IWeatherRepository weatherRepository)
        {
            this.weatherProxy = weatherProxy;
            this.weatherRepository = weatherRepository;
        }
        public string GetWeatherInfo()
        {
            return "";
        }
    }
}