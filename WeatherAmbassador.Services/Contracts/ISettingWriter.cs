namespace WeatherAmbassador.Services.Contracts
{
    public interface ISettingWriter
    {
        void InsertOrUpdate(string settingKey, string settingValue);
    }
}