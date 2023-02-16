using Battleships.Model;

namespace Battleships.Factories
{
	public interface IShipPlacementFactory
	{
		ShipPlacement CreateRandom(IShip ship);
	}
}