using System.Collections.Generic;

namespace ElevatorSimulator.Property
{
	public class Elevator
	{
		public enum Direction
		{
			Up = 1,
			StandBy = 2,
			Down = 3
		}
		public string RandomDirection {get;set;}
		public string UserTargetDirection {get;set;}
		public int WeightLimit { get; set; }
		public int NumberOfElevators { get; set; }
		public int ElevatorNumber { get; set; }
		public int CurrentElevatorFloor { get; set; }
		public int NumberOfCurrentPeopleInElevator { get; set; }
		public int NumberOfDifferentFloor { get; set; }

		public List<Elevator> ElevatorRandomisedStatus { get; set; } = new List<Elevator>();
	}
}
