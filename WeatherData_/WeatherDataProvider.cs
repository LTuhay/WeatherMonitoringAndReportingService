using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringAndReportingService.Bots;

namespace WeatherMonitoringAndReportingService.WeatherData_
{
    public class WeatherDataProvider : IWeatherDataProvider
    {
        private readonly List<IBot> _bots = new List<IBot>();
        private IWeatherData _weatherData;

        public void RegisterObserver(IBot bot)
        {
            _bots.Add(bot);
        }

        public void RemoveObserver(IBot bot)
        {
            _bots.Remove(bot);
        }

        public void NotifyObservers()
        {
            foreach (var bot in _bots)
            {
                bot.Update(_weatherData);
            }
        }

        public void SetWeatherData(IWeatherData weatherData)
        {
            _weatherData = weatherData;
            NotifyObservers();
        }
    }
}
