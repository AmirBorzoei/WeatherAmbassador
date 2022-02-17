using System;
using System.Linq;
using WeatherAmbassador.Persistence.EF.Models;
using WeatherAmbassador.Services.Contracts;

namespace WeatherAmbassador.Persistence.EF.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        public string GetApiCallResult(string apiCallKey)
        {
            using var weatherDbContext = new WeatherDbContext();
            return weatherDbContext.WeatherLogs.FirstOrDefault(w => w.ApiCallKey == apiCallKey)?.ApiCallResult;
        }

        public string GetLatestWeatherLog()
        {
            using var weatherDbContext = new WeatherDbContext();
            return weatherDbContext.WeatherLogs.OrderByDescending(w => w.ApiCallDate).FirstOrDefault()?.ApiCallResult;
        }

        public void AddLatestWeatherLog(string apiCallKey, string apiCallResult)
        {
            var newWeatherLog = new WeatherLog
                    {
                            ApiCallKey = apiCallKey,
                            ApiCallResult = apiCallResult,
                            ApiCallDate = DateTime.Now
                    };

            using var weatherDbContext = new WeatherDbContext();
            weatherDbContext.WeatherLogs.Add(newWeatherLog);
            weatherDbContext.SaveChanges();
        }
    }
}