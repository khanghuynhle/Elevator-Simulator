using ElevatorSimulator.Models;
using ElevatorSimulator.Property;
using System;


namespace ElevatorSimulator
{
	public class Initialiser : IInitialiser
	{
		private readonly Floor _floor;
		private readonly Elevator _elevator;
		private readonly IUserStatus _userStatus;

		public Initialiser(Elevator elevator, Floor floor, IUserStatus userStatus)
		{
			_elevator = elevator;
			_floor = floor;
			_userStatus = userStatus;
		}

		public void InitialiseStatuses()
		{
			Console.Write("Please enter number of elevators: ");
			_elevator.NumberOfElevators = Convert.ToInt32(Console.ReadLine());

			Console.Write("Please enter weight limit for the elevators: ");
			_elevator.WeightLimit = Convert.ToInt32(Console.ReadLine());

			Console.Write("Please enter number of floors in the building: ");
			_floor.BuilddingFloor = Convert.ToInt32(Console.ReadLine());

			_userStatus.RequesUserCurrentStatus();
			_userStatus.RequestElevatorStatus();
		}
	}
}
