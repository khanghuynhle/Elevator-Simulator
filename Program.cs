using ElevatorSimulator;
using ElevatorSimulator.Interfaces;
using ElevatorSimulator.Property;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace ElevatorStimulator
{
	public class Program
	{
		static void Main(string[] args)
		{
			var services = ConfigureServices();

			var serviceProvider = services.BuildServiceProvider();

			// calls the Run method in App, which is replacing Main
			serviceProvider.GetService<App>().Run();

		}
		private static IServiceCollection ConfigureServices()
		{
			IServiceCollection services = new ServiceCollection();

			var config = LoadConfiguration();
			services.AddSingleton(config);

			// required to run the application
			services.AddTransient<IInitialiser, Initialiser>();
			services.AddTransient<IStatusRandomiser, StatusRandomiser>();
			services.AddTransient<IUserStatus, UserRequest>();

			services.AddTransient<App>();

			return services;
		}

		public static IConfiguration LoadConfiguration()
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

			return builder.Build();
		}
	}
}
