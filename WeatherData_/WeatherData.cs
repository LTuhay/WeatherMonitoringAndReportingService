﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringAndReportingService.Bots;

namespace WeatherMonitoringAndReportingService.WeatherData_
{
    public class WeatherData : IWeatherData
    {
        private List<IBot> _bots = new List<IBot>();
        public String CityName {  get; set; }
        public decimal Temperature {  get; set; }
        public decimal Humidity {  get; set; }

    }
}
