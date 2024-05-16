
using Microsoft.Extensions.DependencyInjection;
using WeatherMonitoringAndReportingService.Bots;
using WeatherMonitoringAndReportingService.WeatherData_;
using WeatherMonitoringAndReportingService.WeatherDataEnter;

public class Program
{

    public static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddTransient<IBotFactory, BotFactory>()
            .AddTransient<IWeatherDataProvider, WeatherDataProvider>()
            .BuildServiceProvider();


        IBotConfigLoader botConfigLoader = new BotConfigLoader(serviceProvider);
        IEnumerable<IBotConfig> botConfigs = botConfigLoader.LoadBotConfig(@"..\..\..\botConfig.json");


        IWeatherDataProvider weatherDataProvider = serviceProvider.GetService<IWeatherDataProvider>();
        IBotFactory botFactory = serviceProvider.GetService<IBotFactory>();

        foreach (IBotConfig botConfig in botConfigs)
        {
            IBot bot = botFactory.CreateBot(botConfig);
            weatherDataProvider.RegisterObserver(bot);
        }

        IEneterWeatherData enterWeatherData = new EnterWeatherData();
        IWeatherData weatherData = enterWeatherData.GetWeatherData();


        weatherDataProvider.SetWeatherData(weatherData);
    }

}
