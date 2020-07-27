using ElevatorSimulator.Interfaces;
using ElevatorSimulator.Property;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;

namespace ElevatorStimulator
{
	public class App
	{
		private readonly IConfiguration _config;

		private readonly IStatusRandomiser _statusRamdomiser;
		private readonly IInitialiser _initialiser;
		private readonly Floor _floor;
		private readonly Elevator _elevator;

		public App(IConfiguration config, IStatusRandomiser statusRamdomiser, IInitialiser initialiser)
		{
			_config = config;
			_statusRamdomiser = statusRamdomiser;
			_initialiser = initialiser;
		}
		public void Run()
		{
			var logDirectory = _config.GetValue<string>("Runtime:LogOutputDirectory");
			// Using serilog here, can be anything
			var log = new LoggerConfiguration()
				.WriteTo.Console()
				.WriteTo.File(logDirectory)
				.CreateLogger();

			log.Information("Serilog logger information");
			Console.WriteLine("Hello from App.cs");

			_initialiser.InitialiseStatuses();

			_statusRamdomiser.RandomisePeopleInElevatorOnARandomFloor();

			Console.WriteLine("Number of floor is " + _floor.BuilddingFloor);

			Console.WriteLine("Number of elevator is " + _elevator.NumberOfElevators);

		}
	}
}