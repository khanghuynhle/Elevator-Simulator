namespace ElevatorSimulator.Models
{
	public interface IStatusRandomiser
	{
		int RandomiseCurrentFloor();
		void RandomisePeopleInElevatorAtARandomFloor();
		string RandomDirection();
		void RandomiseWaitingUserOnAFloor();
	}
}
