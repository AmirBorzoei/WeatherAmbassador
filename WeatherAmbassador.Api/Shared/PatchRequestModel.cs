namespace WeatherAmbassador.Api.Shared
{
    public class PatchRequestModel
    {
        public string PropertyName { get; set; }
        public string PropertyNewValue { get; set; }
        public PatchOperation Operation { get; set; }
    }
}