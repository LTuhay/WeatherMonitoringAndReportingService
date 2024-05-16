using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WeatherMonitoringAndReportingService.WeatherData_;
using WeatherMonitoringAndReportingService.Bots;

namespace WeatherMonitoringAndReportingService.WeatherDataEnter
{
    public class JsonAdapter : IWeatherDataEnterAdapter
    {
        IWeatherData IWeatherDataEnterAdapter.EnterWeatherData(string inputData)
        {
            var weatherData = JsonConvert.DeserializeObject<WeatherData>(inputData) ?? new WeatherData();
            return weatherData;
        }
    }
}
