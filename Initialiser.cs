using ElevatorSimulator.Interfaces;
using ElevatorSimulator.Property;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace ElevatorSimulator
{
	public class Initialiser : IInitialiser
	{
		private readonly Floor _floor;
		private readonly Elevator _elevator;
		private readonly NumberOfPeople _numberOfPeople;
		private readonly IStatusRandomiser _statusRandomiser;

		public Initialiser(Elevator elevator, Floor floor, NumberOfPeople numberOfPeople, IStatusRandomiser statusRandomiser)
		{
			_elevator = elevator;
			_floor = floor;
			_numberOfPeople = numberOfPeople;
			_statusRandomiser = statusRandomiser;
		}

		public void InitialiseStatuses()
		{
			Console.Write("Please enter number of elevators: ");
			_elevator.NumberOfElevators = Convert.ToInt32(Console.ReadLine());

			Console.Write("Please enter weight limit for the elevators: ");
			_elevator.WeightLimit = Convert.ToInt32(Console.ReadLine());

			Console.Write("Please enter number of floors in the building: ");
			_floor.BuilddingFloor = Convert.ToInt32(Console.ReadLine());

			_elevator.ElavatorNumber = new int[_elevator.NumberOfElevators];

			for (int i = 0; i < _elevator.NumberOfElevators; i++)
			{
				_elevator.ElavatorNumber[i] = i++;
			}

			_statusRandomiser.RandomiseCurrentFloor();
			_statusRandomiser.RandomisePeopleInElevatorOnARandomFloor();
		}
	}
}
