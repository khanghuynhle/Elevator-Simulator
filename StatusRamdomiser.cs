using System;
using ElevatorSimulator.Models;
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
		public void RandomisePeopleInElevatorAtARandomFloor()
		{
			for (int i = 0; i < _elevator.NumberOfElevators; i++)
			{
				int numberOfCurrentPeopleInElevator = random.Next(0, _elevator.WeightLimit);
				string randomDirection = RandomDirection();
				int currentElevatorFloor = random.Next(0, _floor.BuilddingFloor);
				int elevatorNumber = i + 1 ;

				_elevator.ElevatorRandomisedStatus.Add(
					new Elevator() { NumberOfCurrentPeopleInElevator = numberOfCurrentPeopleInElevator, RandomDirection = randomDirection, CurrentElevatorFloor = currentElevatorFloor, ElevatorNumber = elevatorNumber}
					);
			}
		}
		public void RandomiseWaitingUserOnAFloor()
		{
			for (int i = 0; i < _floor.BuilddingFloor; i++)
			{
				_floor.NumberOfWaitingPeople = random.Next(0, 20);
				_elevator.CurrentElevatorFloor = i + 1;

				Console.WriteLine($"There are {_floor.NumberOfWaitingPeople } people are waiting at floor {_elevator.CurrentElevatorFloor}");
			}
		}
		public string RandomDirection()
		{
			var randomForDirection = (Elevator.Direction)random.Next(1, 3);
			
			if (_elevator.CurrentElevatorFloor > 0 && _elevator.CurrentElevatorFloor < _floor.BuilddingFloor)
			{
				_elevator.RandomDirection = randomForDirection.ToString();
			}
			else if (_elevator.CurrentElevatorFloor == 0)
			{
				randomForDirection = (Elevator.Direction)random.Next(1, 2);
				_elevator.RandomDirection = randomForDirection.ToString();
			}
			else if (_elevator.CurrentElevatorFloor == _floor.BuilddingFloor)
			{
				randomForDirection = (Elevator.Direction)random.Next(2, 3);
				_elevator.RandomDirection = randomForDirection.ToString();
			}
			return _elevator.RandomDirection;
		}
	}
}
