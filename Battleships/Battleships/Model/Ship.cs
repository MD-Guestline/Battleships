using System;
namespace Battleships.Model
{
	public class Ship : IShip
	{
		public int Health { get; private set; }

		public Ship(int size)
		{
			if (size < 1)
			{
				throw new ArgumentOutOfRangeException(nameof(size), "Ship size must be 1 or more.");
			}

			Health = size;
		}

		public void Hit()
		{
			if (Health == 0)
			{
				return;
			}

			Health--;
		}

		public bool IsSunk()
		{
			return Health == 0;
		}
	}
}

