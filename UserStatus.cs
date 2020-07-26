using ElevatorStimulator.Interface;
using System;

namespace ElevatorStimulator
{
	public class UserStatus : IUserStatus
	{
		private int _currentUserFloor = new Floor().CurrentUserFloor;
		private string _direction = new Elevator().Direction;
		private int _targetFloor = new Floor().TargetFloor;
		public UserStatus(int currentUserFloor, int targetFloor, string direction)
		{
			_currentUserFloor = currentUserFloor;
			_targetFloor = targetFloor;
			_direction = direction ?? throw new ArgumentNullException("Direction Can Not Be Found");
		}


		public void RequesUserCurrentStatus(int floor, int direction)
		{
			Console.WriteLine("User is on floor" + _currentUserFloor);

		}
		public void UserRequest(int floor)
		{
			Console.WriteLine("Enter your destination: " + _targetFloor);

			
		}

	}
}