using Battleships.Factories;
using Battleships.Model;
using Moq;

namespace Battleships.Tests.Factories.ShipPlacementFactoryTests
{
    [TestFixture]
    public class CreateRandom
    {
        [TestCase(ShipSize.Battleship, Orientation.Horizontal, 5, 9)]
        [TestCase(ShipSize.Destroyer, Orientation.Horizontal, 6, 9)]
        [TestCase(ShipSize.Battleship, Orientation.Vertical, 9, 5)]
        [TestCase(ShipSize.Destroyer, Orientation.Vertical, 9, 6)]
        public void ShipPassed_GeneratesValidMaxStartCoordinates(ShipSize shipSize, Orientation orientation, int expectedColumn, int expectedRow)
        {
            // Arrange
            var ship = new Ship(shipSize);
            var alwaysSameOrientationAndMaxNumberRandomGenerator = new Mock<IRandomGenerator>();
            alwaysSameOrientationAndMaxNumberRandomGenerator.Setup(generator => generator.NextNumber(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int min, int max) => max - 1);
            alwaysSameOrientationAndMaxNumberRandomGenerator.Setup(generator => generator.NextOrientation())
                .Returns(orientation);
            var shipPlacementFactory = new ShipPlacementFactory(alwaysSameOrientationAndMaxNumberRandomGenerator.Object);

            // Act
            var result = shipPlacementFactory.CreateRandom(ship);

            // Assert
            Assert.That(result.StartColumn, Is.EqualTo(expectedColumn));
            Assert.That(result.StartRow, Is.EqualTo(expectedRow));
        }

        [TestCase(ShipSize.Battleship, Orientation.Horizontal, 0, 0)]
        [TestCase(ShipSize.Destroyer, Orientation.Horizontal, 0, 0)]
        [TestCase(ShipSize.Battleship, Orientation.Vertical, 0, 0)]
        [TestCase(ShipSize.Destroyer, Orientation.Vertical, 0, 0)]
        public void ShipPassed_GeneratesValidMinStartCoordinates(ShipSize shipSize, Orientation orientation, int expectedColumn, int expectedRow)
        {
            // Arrange
            var ship = new Ship(shipSize);
            var alwaysSameOrientationAndMinNumberRandomGenerator = new Mock<IRandomGenerator>();
            alwaysSameOrientationAndMinNumberRandomGenerator.Setup(generator => generator.NextNumber(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int min, int max) => min);
            alwaysSameOrientationAndMinNumberRandomGenerator.Setup(generator => generator.NextOrientation())
                .Returns(orientation);
            var shipPlacementFactory = new ShipPlacementFactory(alwaysSameOrientationAndMinNumberRandomGenerator.Object);

            // Act
            var result = shipPlacementFactory.CreateRandom(ship);

            // Assert
            Assert.That(result.StartColumn, Is.EqualTo(expectedColumn));
            Assert.That(result.StartRow, Is.EqualTo(expectedRow));
        }
    }
}