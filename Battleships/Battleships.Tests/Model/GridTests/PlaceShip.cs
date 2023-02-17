using Battleships.Model;

namespace Battleships.Tests.Model.GridTests
{
    [TestFixture]
    public class PlaceShip
    {
        [Test]
        public void CannotPlaceShip_ThrowsArgumentException()
        {
            // Arrange
            var grid = new Grid();
            var ship = new Ship(ShipSize.Battleship);
            var shipPlacement = new ShipPlacement(Orientation.Horizontal, 9, 9);

            // Act
            void result() => grid.PlaceShip(ship, shipPlacement);

            // Assert
            Assert.That(result, Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void CanPlaceShipHorizontally_PlacesShipOnContiguousSquaresAcrossRow()
        {
            // Arrange
            var grid = new Grid();
            var ship = new Ship(ShipSize.Battleship);
            var shipPlacement = new ShipPlacement(Orientation.Horizontal, 0, 0);

            // Act
            grid.PlaceShip(ship, shipPlacement);

            // Assert
            for (int i = 0; i < ship.Size; i++)
            {
                var expectedGridSquare = grid.GetSquare(shipPlacement.StartColumn + i, shipPlacement.StartRow);
                Assert.That(expectedGridSquare.Ship, Is.EqualTo(ship));
            }
        }

        [Test]
        public void CanPlaceShipVertically_PlacesShipOnContiguousSquaresAcrossColumn()
        {
            // Arrange
            var grid = new Grid();
            var ship = new Ship(ShipSize.Battleship);
            var shipPlacement = new ShipPlacement(Orientation.Vertical, 0, 0);

            // Act
            grid.PlaceShip(ship, shipPlacement);

            // Assert
            for (int i = 0; i < ship.Size; i++)
            {
                var expectedGridSquare = grid.GetSquare(shipPlacement.StartColumn, shipPlacement.StartRow + i);
                Assert.That(expectedGridSquare.Ship, Is.EqualTo(ship));
            }
        }

        [Test]
        public void CanPlaceShipAndNoShipsPlaced_ShipsArePlaced()
        {
            // Arrange
            var grid = new Grid();
            var ship = new Ship(ShipSize.Battleship);
            var shipPlacement = new ShipPlacement(Orientation.Horizontal, 0, 0);
            var gridShipsPlacedBeforePlaceShip = grid.ShipsArePlaced();

            // Act
            grid.PlaceShip(ship, shipPlacement);

            // Assert
            Assert.That(gridShipsPlacedBeforePlaceShip, Is.False);
            Assert.That(grid.ShipsArePlaced, Is.True);
        }
    }
}