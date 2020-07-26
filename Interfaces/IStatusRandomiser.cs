using System;
using System.Collections.Generic;
using System.Text;

namespace ElevatorSimulator.Interfaces
{
	public interface IStatusRandomiser
	{
		int RandomiseCurrentFloor();
		void RandomisePeopleInElevatorOnARandomFloor();
	}
}
