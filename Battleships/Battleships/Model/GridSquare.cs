namespace Battleships.Model
{
	public class GridSquare
	{
		public bool IsShot { get; private set; } = false;
		public IShip? Ship { get; private set; } = null;

		public void Shoot()
		{
			if (IsShot)
			{
				throw new InvalidOperationException("You cannot shoot the same square twice, please try different coordinates.");
			}

			IsShot = true;

			Ship?.Hit();
		}

		public void PlaceShip(IShip ship)
		{
			if (Ship != null)
			{
				throw new InvalidOperationException("There is already a ship placed on this square.");
			}

			Ship = ship;
		}
	}
}