using ElevatorSimulator;
using ElevatorSimulator.Property;
using System;


namespace ElevatorStimulator
{
	public class Program
	{
		//private readonly StatusRandomiser _statusRamdomiser = new StatusRandomiser();
		//private readonly Initialiser _initialiser;
		//private readonly Floor _floor;

		public Program(StatusRandomiser statusRamdomiser, Initialiser initialiser)
		{
			_statusRamdomiser = statusRamdomiser ?? throw new ArgumentNullException("Can not initialise Randomiser");
			_initialiser = initialiser ?? throw new ArgumentNullException("Can not start Initialiser");
		}

		public static void Main(string[] args)
		{
			var initialiser = new Initialiser();
			initialiser.InitialiseStatuses();

			var status = new StatusRandomiser();
			status.RandomisePeopleInElevatorOnARandomFloor();

			var floor = new Floor();
			Console.WriteLine(floor.BuilddingFloor);

		}
	}
}
