using Battleships.Model;

namespace Battleships.Tests.Model.ShipTests
{
    [TestFixture]
	public class IsSunk
	{
		[Test]
		public void HealthIsZero_ReturnsTrue()
		{
            // Arrange
            var ship = new Ship(ShipSize.Destroyer);
            for (var i = (int)ShipSize.Destroyer; i > 0; i--)
            {
                ship.Hit();
            }

            // Act
            var result = ship.IsSunk();

            // Assert
			Assert.That(ship.Health, Is.EqualTo(0));
			Assert.That(result, Is.True);
		}

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void HealthIsGreaterThanZero_ReturnsFalse(int shipHealth)
        {
            // Arrange
            var ship = new Ship(ShipSize.Battleship);
            for (var i = (int)ShipSize.Battleship; i > shipHealth; i--)
            {
                ship.Hit();
            }

            // Act
            var result = ship.IsSunk();

            // Assert
            Assert.That(ship.Health, Is.GreaterThan(0));
            Assert.That(result, Is.False);
        }
    }
}