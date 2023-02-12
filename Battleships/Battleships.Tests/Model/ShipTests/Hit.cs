using Battleships.Model;

namespace Battleships.Tests.Model.ShipTests
{
    [TestFixture]
    public class Hit
    {
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void HealthIsGreaterThanZero_HealthIsDecreasedByOne(int shipHealth)
        {
            // Arrange
            var ship = new Ship(ShipSize.Battleship);
            for (var i = (int)ShipSize.Battleship; i > shipHealth; i--)
            {
                ship.Hit();
            }
            var healthBeforeHit = ship.Health;

            // Act
            ship.Hit();

            // Assert
            Assert.That(ship.Health, Is.EqualTo(healthBeforeHit - 1));
        }

        [Test]
        public void HealthIsZero_HealthRemainsZero()
        {
            // Arrange
            var ship = new Ship(ShipSize.Destroyer);
            for (var i = (int)ShipSize.Destroyer; i > 0; i--)
            {
                ship.Hit();
            }
            var healthBeforeHit = ship.Health;

            // Act
            ship.Hit();

            // Assert
            Assert.That(healthBeforeHit, Is.EqualTo(0));
            Assert.That(ship.Health, Is.EqualTo(0));
        }
    }
}