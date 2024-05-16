
using Microsoft.Extensions.DependencyInjection;
using WeatherMonitoringAndReportingService.Bots;
using WeatherMonitoringAndReportingService.WeatherData_;
using WeatherMonitoringAndReportingService.WeatherDataEnter;

public class Program
{

    public static void Main(string[] args)
    {

        Console.WriteLine("Enter weather data:");
        string userInput = Console.ReadLine();

        IGetWeatherAdapter adapterType = new GetWeatherAdapter();
        IWeatherDataEnterAdapter adapter = adapterType.GetWeatherDataEnterAdapter(userInput);
        IWeatherData weatherData = adapter.EnterWeatherData(userInput);

        var serviceProvider = new ServiceCollection()
            .AddTransient<IBot, RainBot>() 
            .AddTransient<IBot, SunBot>() 
            .AddTransient<IBot, SnowBot>() 
            .BuildServiceProvider();

        String filePath = @"..\..\..\botConfig.json";
        IBotConfigLoader botConfigLoader = new BotConfigLoader(serviceProvider);
        IBotFactory botFactory = new BotFactory();
        IEnumerable<IBot> bots = botConfigLoader.LoadBotConfig(filePath, botFactory);

        foreach (var bot in bots)
        {
            bot.CheckCondition(weatherData.Temperature, weatherData.Humidity);
        }
    }

}
