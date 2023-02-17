using Battleships.Model;

namespace Battleships.Tests.Model.GridTests
{
    [TestFixture]
    public class ShipsArePlaced
    {
        [Test]
        public void NoShipsHaveBeenPlaced_ReturnsFalse()
        {
            // Arrange
            var grid = new Grid();

            // Act
            var result = grid.ShipsArePlaced();

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void ShipsHaveBeenPlaced_ReturnsTrue()
        {
            // Arrange
            var grid = new Grid();
            var ship = new Ship(ShipSize.Battleship);
            var shipPlacement = new ShipPlacement(Orientation.Horizontal, 0, 0);
            grid.PlaceShip(ship, shipPlacement);

            // Act
            var result = grid.ShipsArePlaced();

            // Assert
            Assert.That(result, Is.True);
        }
    }
}