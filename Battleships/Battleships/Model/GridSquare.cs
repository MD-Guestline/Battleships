using System;
namespace Battleships.Model
{
	public class GridSquare
	{
		public bool IsAttacked { get; private set; } = false;
		public IShip? Ship { get; set; } = null;

		public void Shoot()
		{
			if (IsAttacked)
			{
				throw new InvalidOperationException("You cannot attack the same square twice, please try different coordinates.");
			}

			IsAttacked = true;

			Ship?.Hit();
		}
	}
}

