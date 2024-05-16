using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService.Bots
{
    public class BotFactory : IBotFactory
    {

        public IBot CreateBot(BotConfig botConfig)
        {

            Type botType = Type.GetType(botConfig.Type);

            if (botType == null || !typeof(IBot).IsAssignableFrom(botType))
            {
                throw new ArgumentException($"Invalid bot type: {botConfig.Type}");
            }


            IBot bot = (IBot)Activator.CreateInstance(botType);


            bot.Enabled = botConfig.Enabled;
            bot.Message = botConfig.Message;
            bot.TemperatureThreshold = botConfig.TemperatureThreshold;
            bot.HumidityThreshold = botConfig.HumidityThreshold;


            return bot;
        }


    }
}
