namespace WeatherAmbassador.Services.Contracts
{
    public interface IWeatherRepository
    {
        string GetApiCallResult(string apiCallKey);
        string GetLatestWeatherLog();
        void AddLatestWeatherLog(string apiCallKey, string apiCallResult);
    }
}