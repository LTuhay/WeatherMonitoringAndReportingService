using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService.WeatherDataEnter
{
    public interface IGetWeatherAdapter
    {
        public IWeatherDataEnterAdapter GetWeatherDataEnterAdapter(string inputData);
    }
}
