using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherAmbassador.Services.Contracts;

namespace WeatherAmbassador.Api.WeatherForecast
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherService weatherService;

        public WeatherForecastController(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var weatherInfo = weatherService.GetWeatherInfo();
            return Ok(weatherInfo);
        }
    }
}