using Microsoft.AspNetCore.Mvc;
using WeatherAmbassador.Api.Shared;
using WeatherAmbassador.Services.Contracts;

namespace WeatherAmbassador.Api.Controllers
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
            return Ok();
        }
    }
}