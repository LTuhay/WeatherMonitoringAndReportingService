using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WeatherMonitoringAndReportingService.WeatherData_;

namespace WeatherMonitoringAndReportingService.WeatherDataEnter
{
    public class XmlAdapter : IWeatherDataEnterAdapter
    {
        IWeatherData IWeatherDataEnterAdapter.EnterWeatherData(string inputData)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(WeatherData));
            using (StringReader reader = new StringReader(inputData))
            {
                return (WeatherData)serializer.Deserialize(reader);
            }
        }
    }
}
