using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherAmbassador.Api.Shared;
using WeatherAmbassador.Services.Constants;
using WeatherAmbassador.Services.Contracts;

namespace WeatherAmbassador.Api.Setting
{
    [ApiController]
    [Route("[controller]")]
    public class SettingController : ControllerBase
    {
        private readonly ISettingReader settingReader;
        private readonly ISettingWriter settingWriter;

        public SettingController(ISettingReader settingReader, ISettingWriter settingWriter)
        {
            this.settingReader = settingReader;
            this.settingWriter = settingWriter;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var settings = settingReader.GetAllSettings();
            return Ok(settings);
        }
        
        [HttpPatch]
        public IActionResult Patch(PatchRequestModel patchRequestModel)
        {
            if (!SettingKey.AllSettingKeys.Contains(patchRequestModel.PropertyName))
            {
                throw new BadHttpRequestException($"{patchRequestModel.PropertyName} not exist!");
            }

            settingWriter.InsertOrUpdate(patchRequestModel.PropertyName, patchRequestModel.PropertyNewValue);
            return Ok();
        }
    }
}