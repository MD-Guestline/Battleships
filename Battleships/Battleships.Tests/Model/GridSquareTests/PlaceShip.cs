using Battleships.Model;

namespace Battleships.Tests.Model.GridSquareTests
{
    [TestFixture]
	public class PlaceShip
	{
        [Test]
        public void ShipAlreadyPlaced_ThrowsInvalidOperationException()
        {
            // Arrange
            var gridSquare = new GridSquare();
            var existingShip = new Ship(ShipSize.Destroyer);
            var newShip = new Ship(ShipSize.Battleship);
            gridSquare.PlaceShip(existingShip);
            
            // Act
            void result() => gridSquare.PlaceShip(newShip);

            // Assert
            Assert.That(result, Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
		public void HasNoShip_PlacesShip()
		{
            // Arrange
			var gridSquare = new GridSquare();
            var newShip = new Ship(ShipSize.Battleship);
            var gridSquareShipBeforePlacing = gridSquare.Ship;

            // Act
            gridSquare.PlaceShip(newShip);

            // Assert
            Assert.That(gridSquareShipBeforePlacing, Is.Null);
			Assert.That(gridSquare.Ship, Is.EqualTo(newShip));
		}
    }
}