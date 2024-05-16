
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

        // Cargar la configuración de los bots
        IBotConfigLoader botConfigLoader = new BotConfigLoader(serviceProvider);
        IEnumerable<IBotConfig> botConfigs = botConfigLoader.LoadBotConfig(@"..\..\..\botConfig.json");

        // Crear los bots y registrarlos como observadores del proveedor de datos climáticos
        IWeatherDataProvider weatherDataProvider = serviceProvider.GetService<IWeatherDataProvider>();
        IBotFactory botFactory = serviceProvider.GetService<IBotFactory>();

        foreach (IBotConfig botConfig in botConfigs)
        {
            IBot bot = botFactory.CreateBot(botConfig);
            weatherDataProvider.RegisterObserver(bot);
        }

        // Obtener la configuración del clima y actualizar los datos del proveedor de datos climáticos
        Console.WriteLine("Ingrese la configuración del clima en formato JSON o XML:");
        string userInput = Console.ReadLine();

        IGetWeatherAdapter adapterType = new GetWeatherAdapter();
        IWeatherDataEnterAdapter adapter = adapterType.GetWeatherDataEnterAdapter(userInput);
        IWeatherData weatherData = adapter.EnterWeatherData(userInput);

        weatherDataProvider.SetWeatherData(weatherData);
    }

}
