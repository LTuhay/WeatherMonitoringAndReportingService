using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringAndReportingService.WeatherData_;

namespace WeatherMonitoringAndReportingService.Bots
{
    public interface IBot
    {
        void Update(IWeatherData weatherData);
    }
}
