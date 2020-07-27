using ElevatorSimulator.Models;
using ElevatorSimulator.Property;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;

namespace ElevatorStimulator
{
	public class App
	{
		private readonly IConfiguration _config;

		private readonly IInitialiser _initialiser;
		private readonly IUserStatus _userStatus;
		private readonly Floor _floor;
		private readonly IElevatorProcessing _elevatorProcessing;

		public App(IConfiguration config, IInitialiser initialiser, IUserStatus userStatus, Floor floor, IElevatorProcessing elevatorProcessing)
		{
			_config = config;
			_initialiser = initialiser;
			_floor = floor;
			_userStatus = userStatus;
			_elevatorProcessing = elevatorProcessing;
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

			_userStatus.RequesUserCurrentStatus();

			Console.Write("The floor number you would like to go to: ");

			_floor.TargetFloor = Convert.ToInt32(Console.ReadLine());

			_elevatorProcessing.CallElevator();
		}
	}
}