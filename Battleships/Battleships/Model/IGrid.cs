using System;
namespace Battleships.Model
{
	public interface IGrid
	{
        const int Size = 10;

        void ShootSquare(int columnIndex, int rowIndex);
        GridSquare GetSquare(int columnIndex, int rowIndex);
        bool CanPlaceShip(IShip ship, ShipPlacement shipPlacement);
        void PlaceShip(IShip ship, ShipPlacement shipPlacement);
        bool ShipsArePlaced();
        bool AllShipsAreSunk();
    }
}

