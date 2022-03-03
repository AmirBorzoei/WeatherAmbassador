using System;
using NUnit.Framework;
using Moq;
using WeatherAmbassador.Services.Constants;
using WeatherAmbassador.Services.Contracts;

namespace WeatherAmbassador.Services.Test
{
    public class WeatherServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenApiFailedAndDBIsEmptyShouldReturnNull()
        {
            var weatherProxyMock = new Mock<IWeatherProxy>();
            weatherProxyMock.Setup(p => p.CallApi()).Throws<TimeoutException>();

            var weatherRepositoryMock = new Mock<IWeatherRepository>();
            weatherRepositoryMock.Setup(r => r.GetApiCallResult(It.IsAny<string>())).Returns((string)null);

            var settingReaderMock = new Mock<ISettingReader>();
            settingReaderMock.Setup(s => s.GetSettingValue(SettingKey.WeatherApiCallIntervalFormat)).Returns("");

            var service = new WeatherService(weatherProxyMock.Object, weatherRepositoryMock.Object, settingReaderMock.Object);

            var result = service.GetWeatherInfo();

            Assert.IsNull(result);
        }

        [Test]
        public void WhenApiFailedAndDBIsNotEmptyShouldReturnDBValue()
        {
            var expectedValue = "XXXX";

            var weatherProxyMock = new Mock<IWeatherProxy>();
            weatherProxyMock.Setup(p => p.CallApi()).Throws<TimeoutException>();

            var weatherRepositoryMock = new Mock<IWeatherRepository>();
            weatherRepositoryMock.Setup(r => r.GetApiCallResult(It.IsAny<string>())).Returns(expectedValue);

            var settingReaderMock = new Mock<ISettingReader>();
            settingReaderMock.Setup(s => s.GetSettingValue(SettingKey.WeatherApiCallIntervalFormat)).Returns("");

            var service = new WeatherService(weatherProxyMock.Object, weatherRepositoryMock.Object, settingReaderMock.Object);

            var result = service.GetWeatherInfo();

            Assert.AreEqual(expectedValue, result);
        }

        [Test]
        public void WhenApiSuccessedShouldReturnApiResult()
        {
            var expectedValue = "XXXX";

            var weatherProxyMock = new Mock<IWeatherProxy>();
            weatherProxyMock.Setup(p => p.CallApi()).Returns(expectedValue);

            var weatherRepositoryMock = new Mock<IWeatherRepository>();
            weatherRepositoryMock.Setup(r => r.GetApiCallResult(It.IsAny<string>())).Returns(It.IsAny<string>());

            var settingReaderMock = new Mock<ISettingReader>();
            settingReaderMock.Setup(s => s.GetSettingValue(SettingKey.WeatherApiCallIntervalFormat)).Returns("");

            var service = new WeatherService(weatherProxyMock.Object, weatherRepositoryMock.Object, settingReaderMock.Object);

            var result = service.GetWeatherInfo();

            Assert.AreEqual(expectedValue, result);

            weatherRepositoryMock.Verify(r => r.GetLatestWeatherLog(), Times.Never);
        }
    }
}