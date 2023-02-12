using Battleships.Model;
using Moq;

namespace Battleships.Tests.Model.GridTests
{
    [TestFixture]
	public class AllShipsAreSunk
	{
        [Test]
        public void NoShipsHaveBeenPlaced_ReturnsTrue()
        {
            // Arrange
            var grid = new Grid();

            // Act
            var result = grid.AllShipsAreSunk();

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void AllPlacedShipsAreSunk_ReturnsTrue()
        {
            // Arrange
            var grid = new Grid();
            var firstShip = new Mock<IShip>();
            firstShip.Setup(ship => ship.IsSunk()).Returns(true);
            firstShip.Setup(ship => ship.Size).Returns(5);
            var secondShip = new Mock<IShip>();
            secondShip.Setup(ship => ship.IsSunk()).Returns(true);
            secondShip.Setup(ship => ship.Size).Returns(4);
            var firstShipPlacement = new ShipPlacement(Orientation.Horizontal, 0, 0);
            var secondShipPlacement = new ShipPlacement(Orientation.Horizontal, 5, 0);
            grid.PlaceShip(firstShip.Object, firstShipPlacement);
            grid.PlaceShip(secondShip.Object, secondShipPlacement);

            // Act
            var result = grid.AllShipsAreSunk();

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void NotAllPlacedShipsAreSunk_ReturnsFalse()
        {
            // Arrange
            var grid = new Grid();
            var firstShip = new Mock<IShip>();
            firstShip.Setup(ship => ship.IsSunk()).Returns(false);
            firstShip.Setup(ship => ship.Size).Returns(5);
            var secondShip = new Mock<IShip>();
            secondShip.Setup(ship => ship.IsSunk()).Returns(true);
            secondShip.Setup(ship => ship.Size).Returns(4);
            var firstShipPlacement = new ShipPlacement(Orientation.Horizontal, 0, 0);
            var secondShipPlacement = new ShipPlacement(Orientation.Horizontal, 5, 0);
            grid.PlaceShip(firstShip.Object, firstShipPlacement);
            grid.PlaceShip(secondShip.Object, secondShipPlacement);

            // Act
            var result = grid.AllShipsAreSunk();

            // Assert
            Assert.That(result, Is.False);
        }
    }
}