namespace ElevatorStimulator.Interface
{
	public interface IUserStatus
	{
		public void UserRequest(int floor);
		public void RequesUserCurrentStatus(int floor, int direction);
	}
}
