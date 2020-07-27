using ElevatorSimulator.Models;
using ElevatorSimulator.Property;
using System;

namespace ElevatorSimulator
{
	public class UserRequest : IUserStatus
	{
		private readonly Floor _floor;
		private readonly Elevator _elevator;
		private readonly IStatusRandomiser _randomiser;
		public UserRequest(Elevator elevator, Floor floor, IStatusRandomiser randomiser)
		{
			_elevator = elevator;
			_floor = floor;
			_randomiser = randomiser;
		}

		public void RequesUserCurrentStatus()
		{
			_randomiser.RandomiseCurrentFloor();

			Console.WriteLine("Your are on floor " + _floor.CurrentUserFloor);
		}
		public void RequestElevatorStatus()
		{
				_randomiser.RandomisePeopleInElevatorAtARandomFloor();
				_randomiser.RandomiseWaitingUserOnAFloor();

				foreach (Elevator elevatorStatus in _elevator.ElevatorRandomisedStatus)
				{
					Console.WriteLine($"There are {elevatorStatus.NumberOfCurrentPeopleInElevator} people in elevator number {elevatorStatus.ElevatorNumber} going Up at floor {elevatorStatus.CurrentElevatorFloor}");
				}
		}
	}
}