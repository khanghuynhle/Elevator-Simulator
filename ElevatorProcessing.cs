using ElevatorSimulator.Models;
using ElevatorSimulator.Property;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElevatorSimulator
{
	public class ElevatorProcessing : IElevatorProcessing
	{
		private readonly Floor _floor;
		private readonly Elevator _elevator;
		public ElevatorProcessing(Floor floor, Elevator elevator)
		{
			_floor = floor;
			_elevator = elevator;
		}
		public void CallElevator()
		{
			while (!Enumerable.Range(0, _floor.BuilddingFloor).Contains(_floor.TargetFloor))
			{
				Console.Write("Please re-enter the destination floor: ");
				_floor.TargetFloor = Convert.ToInt32(Console.ReadLine());
			}
			//Pre check with the direction
			if (_floor.CurrentUserFloor > _floor.TargetFloor)
			{
				_elevator.UserTargetDirection = Elevator.Direction.Down.ToString();
			}
			else if (_floor.CurrentUserFloor < _floor.TargetFloor)
			{
				_elevator.UserTargetDirection = Elevator.Direction.Up.ToString();
			}
			else
			{
				_elevator.UserTargetDirection = Elevator.Direction.StandBy.ToString();
				Console.WriteLine("You are at the destination.");
				return;
			}
			ElevatorLogic();
		}
		public void ElevatorLogic()
		{
			List<Elevator> elevatorFloorSorted = _elevator.ElevatorRandomisedStatus.OrderBy(elevator => elevator.CurrentElevatorFloor).ThenBy(elevator => elevator.NumberOfCurrentPeopleInElevator).ToList();

			foreach (Elevator elevatorStatus in elevatorFloorSorted)
			{
					while (elevatorStatus.NumberOfCurrentPeopleInElevator < _elevator.WeightLimit && Enumerable.Range(0, _floor.BuilddingFloor).Contains(_floor.TargetFloor))
					{
						if (elevatorStatus.RandomDirection == _elevator.UserTargetDirection)
						{
							Console.WriteLine($"Please go to elevator number {elevatorStatus.ElevatorNumber} which has {elevatorStatus.NumberOfCurrentPeopleInElevator} people at floor {elevatorStatus.CurrentElevatorFloor}");
							return;
						}
						else if (elevatorStatus.RandomDirection != _elevator.UserTargetDirection && elevatorStatus.RandomDirection.Equals("StandBy"))
						{
							List<Elevator> closestElevators = new List<Elevator>();

							int elevatorNum = elevatorStatus.ElevatorNumber;

							closestElevators.Add(new Elevator { NumberOfDifferentFloor = Math.Abs(_floor.CurrentUserFloor - _floor.TargetFloor), ElevatorNumber = elevatorNum });

							closestElevators.OrderBy(x => x.NumberOfDifferentFloor).ToList();

							foreach (Elevator closestElevator in closestElevators)
							{
								Console.WriteLine($"Please go to elevator number {closestElevator.ElevatorNumber} which has {closestElevator.NumberOfCurrentPeopleInElevator} people at floor {closestElevator.CurrentElevatorFloor}");
								return;
							}
						}
						else
						{
							elevatorFloorSorted.OrderBy(elevator => elevator.CurrentElevatorFloor);
							Console.WriteLine($"Please go to elevator number {elevatorStatus.ElevatorNumber} which has {elevatorStatus.NumberOfCurrentPeopleInElevator} people at floor {elevatorStatus.CurrentElevatorFloor}");
							return;
						}
					
					}
					
			}

		}
	}
}


