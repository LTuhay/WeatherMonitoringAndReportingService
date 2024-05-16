using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService.Bots
{
    public class RainBot : IBot
    {
        public string Type { get; set; }
        public bool Enabled { get; set; }
        public decimal HumidityThreshold { get; set; }
        public decimal TemperatureThreshold { get; set; }
        public string Message { get; set; }


        public void PrintMessage()
        {
            if (Enabled)
            {
                Console.WriteLine(Message);
            }
        }

        public void CheckCondition(decimal temperature, decimal humidity)
        {
            if (humidity > HumidityThreshold)
            {
                PrintMessage();
            }
        }
    }
}
