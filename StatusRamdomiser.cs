using System;
using ElevatorSimulator.Interfaces;
using ElevatorSimulator.Property;

namespace ElevatorSimulator
{
	public class StatusRandomiser : IStatusRandomiser
	{
		private readonly Floor _floor;
		private readonly Elevator _elevator;
		Random random = new Random();

		public StatusRandomiser(Floor floor, Elevator elevator)
		{
			_floor = floor;
			_elevator = elevator;
		}

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

		}
	}
}
