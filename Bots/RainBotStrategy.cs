using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringAndReportingService.WeatherData_;

namespace WeatherMonitoringAndReportingService.Bots
{
    public class RainBotStrategy : IBotStrategy
    {
        private readonly decimal _threshold;

        public RainBotStrategy(decimal threshold)
        {
            _threshold = threshold;
        }

        public void Execute(IWeatherData weatherData, string message)
        {
            if (weatherData.Humidity > _threshold)
            {
                Console.WriteLine(message);
            }
        }
    }

}
