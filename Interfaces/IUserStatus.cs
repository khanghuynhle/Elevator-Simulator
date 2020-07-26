﻿namespace ElevatorStimulator.Interfaces
{
	public interface IUserStatus
	{
		void SendUserRequest(int floor);
		void RequesUserCurrentStatus();
		void RequestElevatorStatus();
	}
}
