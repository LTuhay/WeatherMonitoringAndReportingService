using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService.WeatherData_
{
    public interface IEneterWeatherData
    {
        public IWeatherData GetWeatherData();
        
    }
}
