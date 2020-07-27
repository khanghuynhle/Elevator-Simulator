using ElevatorSimulator.Interfaces;
using ElevatorSimulator.Property;
using System;

namespace ElevatorSimulator
{
	public class UserRequest : IUserStatus
	{
		private readonly Floor _floor;
		private readonly Elevator _elevator;
		private readonly NumberOfPeople _numberOfPeople;
		public UserRequest(Elevator elevator, Floor floor, NumberOfPeople numberOfPeople)
		{
			_elevator = elevator ?? throw new ArgumentNullException("Elevator can Not Be Found");
			_floor = floor ?? throw new ArgumentNullException("Floor can not be found");
			_numberOfPeople = _numberOfPeople ?? throw new ArgumentNullException("Number of people in elevator cannot be found");
		}


		public void RequesUserCurrentStatus()
		{
			Console.WriteLine("User is on floor" + _floor.CurrentUserFloor);
		}
		public void RequestElevatorStatus()
		{ 
			for(int i =0; i < _elevator.NumberOfElevators; i++)
			{
				Console.WriteLine($"There are {_elevator.NumberOfCurrentPeopleInElevator } in {_elevator.ElavatorNumber} going {_elevator.RandomDirection}");
			}
		}
		public void SendUserRequest(int floor)
		{
			Console.WriteLine("Enter your destination: " + _floor.TargetFloor);

			
		}

	}
}