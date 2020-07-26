using System;
using ElevatorSimulator.Interfaces;
using ElevatorSimulator.Property;

namespace ElevatorSimulator
{
	public class StatusRandomiser : IStatusRandomiser
	{
		private readonly Floor _floor = new Floor();
		private readonly Elevator _elevator = new Elevator();
		Random random = new Random();
	
		//public StatusRamdomiser()
		//{
		//	//initialise base
		//}
		//public StatusRamdomiser(Floor floor){
		//	_floor = floor ?? throw new ArgumentNullException("Floor can not be found");	
		//}

		public int RandomiseCurrentFloor()
		{
			_floor.CurrentUserFloor = random.Next(0, _floor.BuilddingFloor);

			return _floor.CurrentUserFloor;
		}
		public void RandomisePeopleInElevatorOnARandomFloor()
		{
			var randomForDirection = (Elevator.Direction)random.Next(1, 2);

			var elevatorStatus = new Elevator
			{
				CurrentElevatorFloor = random.Next(0, _floor.BuilddingFloor),
				NumberOfCurrentPeopleInElevator = random.Next(0, _elevator.WeightLimit),
				RandomDirection = randomForDirection.ToString()
			};
			Console.WriteLine(elevatorStatus);

		}
	}
}
