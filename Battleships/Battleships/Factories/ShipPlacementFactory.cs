using Battleships.Model;

namespace Battleships.Factories
{
    public class ShipPlacementFactory : IShipPlacementFactory
    {
        private readonly IRandomGenerator _random;

        public ShipPlacementFactory(IRandomGenerator random)
        {
            _random = random;
        }

        public ShipPlacement CreateRandom(IShip ship)
        {
            var orientation = _random.NextOrientation();
            int startColumn;
            int startRow;

            if (orientation == Orientation.Horizontal)
            {
                startColumn = _random.NextNumber(0, Grid.Size - ship.Size + 1);
                startRow = _random.NextNumber(0, Grid.Size);
            }
            else
            {
                startColumn = _random.NextNumber(0, Grid.Size);
                startRow = _random.NextNumber(0, Grid.Size - ship.Size + 1);
            }

            return new ShipPlacement(orientation, startColumn, startRow);
        }
    }
}