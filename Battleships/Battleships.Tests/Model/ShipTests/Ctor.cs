using Battleships.Model;

namespace Battleships.Tests.Model.ShipTests
{
    [TestFixture]
    public class Ctor
    {
        [TestCase(ShipSize.Destroyer)]
        [TestCase(ShipSize.Battleship)]
        public void ShipSizePassedToConstructor_ShipHealthAndSizeEqualToShipSize(ShipSize shipSize)
        {
            // Act
            var ship = new Ship(shipSize);

            // Assert
            Assert.That(ship.Health, Is.EqualTo((int)shipSize));
            Assert.That(ship.Size, Is.EqualTo((int)shipSize));
        }
    }
}