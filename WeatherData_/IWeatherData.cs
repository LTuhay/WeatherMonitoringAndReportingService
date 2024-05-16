using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringAndReportingService.Bots;

namespace WeatherMonitoringAndReportingService.WeatherData_
{
    public interface IWeatherData
    {
        string CityName { get; set; }
        decimal Temperature { get; set; }
        decimal Humidity { get; set; }

        void AddBotObserver(IBot bot);
        void RemoveBotObserver(IBot bot);
 //       void TriggerBotUpdates();

    }
}
