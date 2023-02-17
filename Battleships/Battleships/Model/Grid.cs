namespace Battleships.Model
{
    public class Grid : IGrid
    {
        public const int Size = 10;
        private readonly GridSquare[,] _gridSquares = new GridSquare[Size, Size];
        private readonly List<IShip> _placedShips = new List<IShip>();

        public Grid()
        {
            for (var rowIndex = 0; rowIndex < Size; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < Size; columnIndex++)
                {
                    _gridSquares[rowIndex, columnIndex] = new GridSquare();
                }
            }
        }

        public void ShootSquare(int columnIndex, int rowIndex)
        {
            if (columnIndex < 0 || columnIndex >= Size)
            {
                throw new ArgumentOutOfRangeException(nameof(columnIndex));
            }

            if (rowIndex < 0 || rowIndex >= Size)
            {
                throw new ArgumentOutOfRangeException(nameof(rowIndex));
            }

            _gridSquares[rowIndex, columnIndex].Shoot();
        }

        public GridSquare GetSquare(int columnIndex, int rowIndex)
        {
            if (columnIndex < 0 || columnIndex >= Size)
            {
                throw new ArgumentOutOfRangeException(nameof(columnIndex));
            }

            if (rowIndex < 0 || rowIndex >= Size)
            {
                throw new ArgumentOutOfRangeException(nameof(rowIndex));
            }

            return _gridSquares[rowIndex, columnIndex];
        }

        public bool CanPlaceShip(IShip ship, ShipPlacement shipPlacement)
        {
            if (StartCoordinatesOutOfBounds(shipPlacement))
            {
                throw new ArgumentOutOfRangeException(nameof(shipPlacement));
            }

            if (ShipPlacementOutOfBounds(ship, shipPlacement))
            {
                return false;
            }

            if (ShipOverlapsWithAlreadyPlacedShip(ship, shipPlacement))
            {
                return false;
            }

            return true;
        }

        public void PlaceShip(IShip ship, ShipPlacement shipPlacement)
        {
            if (!CanPlaceShip(ship, shipPlacement))
            {
                throw new ArgumentException("Ship cannot be placed at the requested coordinates.");
            }

            for (var i = 0; i < ship.Size; i++)
            {
                if (shipPlacement.Orientation == Orientation.Horizontal)
                {
                    _gridSquares[shipPlacement.StartRow, shipPlacement.StartColumn + i].PlaceShip(ship);
                }
                else if (shipPlacement.Orientation == Orientation.Vertical)
                {
                    _gridSquares[shipPlacement.StartRow + i, shipPlacement.StartColumn].PlaceShip(ship);
                }
            }

            _placedShips.Add(ship);
        }

        public bool ShipsArePlaced()
        {
            return _placedShips.Count() > 0;
        }

        public bool AllShipsAreSunk()
        {
            return _placedShips.All(ship => ship.IsSunk());

        }

        private bool StartCoordinatesOutOfBounds(ShipPlacement shipPlacement)
        {
            return shipPlacement.StartColumn < 0 || shipPlacement.StartColumn >= Size ||
                   shipPlacement.StartRow < 0 || shipPlacement.StartRow >= Size;
        }

        private bool ShipPlacementOutOfBounds(IShip ship, ShipPlacement shipPlacement)
        {
            if (shipPlacement.Orientation == Orientation.Horizontal)
            {
                return shipPlacement.StartColumn > Size - ship.Size;
            }
            else if (shipPlacement.Orientation == Orientation.Vertical)
            {
                return shipPlacement.StartRow > Size - ship.Size;
            }

            return false;
        }

        private bool ShipOverlapsWithAlreadyPlacedShip(IShip ship, ShipPlacement shipPlacement)
        {
            for (var i = 0; i < ship.Size; i++)
            {
                if (shipPlacement.Orientation == Orientation.Horizontal)
                {
                    if (_gridSquares[shipPlacement.StartRow, shipPlacement.StartColumn + i].Ship != null)
                    {
                        return true;
                    }
                }
                else if (shipPlacement.Orientation == Orientation.Vertical)
                {
                    if (_gridSquares[shipPlacement.StartRow + i, shipPlacement.StartColumn].Ship != null)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}