using Battleships.Factories;
using Battleships.Model;
using Battleships.View;
using Moq;

namespace Battleships.Tests.GameTests
{
    [TestFixture]
    public class IsOver
    {
        private Mock<IGrid> _grid;
        private Mock<IGameView> _gameView;
        private Mock<IShipPlacementFactory> _shipPlacementFactory;

        [SetUp]
        public void Setup()
        {
            _grid = new Mock<IGrid>();
            _gameView = new Mock<IGameView>();
            _shipPlacementFactory = new Mock<IShipPlacementFactory>();
        }

        [Test]
        public void ShipsAreNotPlaced_ReturnsFalse()
        {
            // Arrange
            _grid.Setup(grid => grid.ShipsArePlaced()).Returns(false);
            _grid.Setup(grid => grid.AllShipsAreSunk()).Returns(true);

            var game = new Game(_grid.Object, _gameView.Object, _shipPlacementFactory.Object);

            // Act
            var result = game.IsOver();

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void NotAllShipsAreSunk_ReturnsFalse()
        {
            // Arrange
            _grid.Setup(grid => grid.ShipsArePlaced()).Returns(true);
            _grid.Setup(grid => grid.AllShipsAreSunk()).Returns(false);

            var game = new Game(_grid.Object, _gameView.Object, _shipPlacementFactory.Object);

            // Act
            var result = game.IsOver();

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void ShipsAreNotPlacedAndNotAllShipsAreSunk_ReturnsFalse()
        {
            // Arrange
            _grid.Setup(grid => grid.ShipsArePlaced()).Returns(false);
            _grid.Setup(grid => grid.AllShipsAreSunk()).Returns(false);

            var game = new Game(_grid.Object, _gameView.Object, _shipPlacementFactory.Object);

            // Act
            var result = game.IsOver();

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void ShipsArePlacedAndAllShipsAreSunk_ReturnsTrue()
        {
            // Arrange
            _grid.Setup(grid => grid.ShipsArePlaced()).Returns(true);
            _grid.Setup(grid => grid.AllShipsAreSunk()).Returns(true);

            var game = new Game(_grid.Object, _gameView.Object, _shipPlacementFactory.Object);

            // Act
            var result = game.IsOver();

            // Assert
            Assert.That(result, Is.True);
        }
    }
}