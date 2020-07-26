namespace ElevatorSimulator.Property
{
	public class Elevator
	{
		public enum Direction
		{
			Up,
			Down
		}
		public string RandomDirection {get;set;}
		public int WeightLimit { get; set; }
		public int NumberOfElevators { get; set; }
		public int[] ElavatorNumber { get; set; }

		public int CurrentElevatorFloor { get; set; }
		public int NumberOfCurrentPeopleInElevator { get; set; }
	}
}
