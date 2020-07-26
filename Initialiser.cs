using ElevatorSimulator.Interfaces;
using ElevatorSimulator.Property;
using System;

namespace ElevatorSimulator
{
	public class Initialiser : IInitialiser
	{
		private readonly Floor _floor = new Floor();
		private readonly Elevator _elevator = new Elevator();
		private readonly NumberOfPeople _numberOfPeople = new NumberOfPeople();
		private readonly StatusRandomiser _statusRandomiser = new StatusRandomiser();
		
		//public Initialiser()
		//{
		//	//initialise base
		//}

		//public Initialiser(Elevator elevator, Floor floor, NumberOfPeople numberOfPeople, StatusRandomiser statusRandomiser)
		//{
		//	_elevator = elevator ?? throw new ArgumentNullException("Elevator can Not Be Found");
		//	_floor = floor ?? throw new ArgumentNullException("Floor can not be found");
		//	_numberOfPeople = numberOfPeople ?? throw new ArgumentNullException("Number of people in elevator cannot be found");
		//	_statusRandomiser = statusRandomiser ?? throw new ArgumentNullException("Status Randomiser is not available");
		//}

		public void InitialiseStatuses()
		{
			Console.Write("Please enter number of elevators: ");
			_elevator.NumberOfElevators = Convert.ToInt32(Console.ReadLine());

			Console.Write("Please enter weight limit for the elevators: ");
			_elevator.WeightLimit = Convert.ToInt32(Console.ReadLine());

			Console.Write("Please enter number of floors in the building: ");
			_floor.BuilddingFloor = Convert.ToInt32(Console.ReadLine());

			_elevator.ElavatorNumber = new int[_elevator.NumberOfElevators];

			for(int i = 0; i < _elevator.NumberOfElevators; i++)
			{
				_elevator.ElavatorNumber[i] = i++;
			}

			_statusRandomiser.RandomiseCurrentFloor();
			_statusRandomiser.RandomisePeopleInElevatorOnARandomFloor();
		}
	}
}
