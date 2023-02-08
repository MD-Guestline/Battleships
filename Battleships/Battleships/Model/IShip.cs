using System;
namespace Battleships.Model
{
	public interface IShip
	{
		void Hit();
		bool IsSunk(); 
	}
}

