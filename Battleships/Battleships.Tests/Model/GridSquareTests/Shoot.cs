using Battleships.Model;

namespace Battleships.Tests.Model.GridSquareTests
{
    [TestFixture]
    public class Shoot
    {
        [Test]
        public void IsAlreadyShot_ThrowsInvalidOperationException()
        {
            // Arrange
            var gridSquare = new GridSquare();
            gridSquare.Shoot();
            var shotBefore = gridSquare.IsShot;

            // Act
            void result() => gridSquare.Shoot();

            // Assert
            Assert.That(shotBefore, Is.True);
            Assert.That(result, Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void IsNotShot_BecomesShot()
        {
            // Arrange
            var gridSquare = new GridSquare();
            var shotBefore = gridSquare.IsShot;

            // Act
            gridSquare.Shoot();

            // Assert
            Assert.That(shotBefore, Is.False);
            Assert.That(gridSquare.IsShot, Is.True);
        }

        [Test]
        public void IsNotShotAndHasAShip_HitsShip()
        {
            // Arrange
            var gridSquare = new GridSquare();
            var ship = new Ship(ShipSize.Battleship);
            gridSquare.PlaceShip(ship);
            var healthBeforeHit = ship.Health;

            // Act
            gridSquare.Shoot();

            // Assert
            Assert.That(ship.Health, Is.EqualTo(healthBeforeHit - 1));
        }
    }
}