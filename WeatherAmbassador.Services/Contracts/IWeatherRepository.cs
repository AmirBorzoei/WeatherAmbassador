namespace WeatherAmbassador.Services.Contracts
{
    public interface IWeatherRepository
    {
        string GetWeatherLog(string apiCallKey);

        void AddLatestWeatherLog(string apiCallKey, string apiCallResult);
    }
}