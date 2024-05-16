using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WeatherMonitoringAndReportingService.Bots
{
    public class BotConfigLoader : IBotConfigLoader
    {
        private readonly IServiceProvider _serviceProvider;

        public BotConfigLoader(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IEnumerable<IBotConfig> LoadBotConfig(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Configuration file not found", filePath);
            }

            string jsonContent = File.ReadAllText(filePath);
            JObject botConfigDict = JsonConvert.DeserializeObject<JObject>(jsonContent);

            List<IBotConfig> botConfigs = new List<IBotConfig>();

            foreach (var botConfigEntry in botConfigDict)
            {
                string botName = botConfigEntry.Key;
                JObject botConfigJson = botConfigEntry.Value as JObject;

                BotConfig botConfig = new BotConfig
                {
                    Type = botName,
                    Enabled = botConfigJson.Value<bool>("enabled"),
                    HumidityThreshold = botConfigJson.Value<decimal>("humidityThreshold"),
                    TemperatureThreshold = botConfigJson.Value<decimal>("temperatureThreshold"),
                    Message = botConfigJson.Value<string>("message")
                };

                botConfigs.Add(botConfig);
            }

            return botConfigs;
        }

    }


}
