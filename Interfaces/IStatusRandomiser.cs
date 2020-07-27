namespace ElevatorSimulator.Interfaces
{
	public interface IStatusRandomiser
	{
		int RandomiseCurrentFloor();
		void RandomisePeopleInElevatorOnARandomFloor();
	}
}
