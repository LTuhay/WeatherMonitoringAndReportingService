using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringAndReportingService.WeatherDataEnter;

namespace WeatherMonitoringAndReportingService.WeatherData_
{
    public class EnterWeatherData : IEneterWeatherData
    {
        public IWeatherData GetWeatherData()
        {

            Console.WriteLine("Enter weather data:");
            string userInput = Console.ReadLine();

            IGetWeatherAdapter adapterType = new GetWeatherAdapter();
            IWeatherDataEnterAdapter adapter = adapterType.GetWeatherDataEnterAdapter(userInput);
            return adapter.EnterWeatherData(userInput);
        }
    }
}
