using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService.WeatherDataEnter
{
    public class GetWeatherAdapter : IGetWeatherAdapter
    {
        public IWeatherDataEnterAdapter GetWeatherDataEnterAdapter(string inputData)
        {
            if (inputData.StartsWith("{")) 
            {
                return new JsonAdapter();
            }
            else if (inputData.StartsWith("<")) 
            {
                return new XmlAdapter();
            }

            return null;
        }

    }
}
