using Battleships.Factories;
using Battleships.Model;
using Battleships.View;
using Moq;

namespace Battleships.Tests.GameTests
{
    [TestFixture]
    public class End
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
        public void GameIsOver_DisplaysGameOverMessage()
        {
            // Arrange
            _grid.Setup(grid => grid.ShipsArePlaced()).Returns(true);
            _grid.Setup(grid => grid.AllShipsAreSunk()).Returns(true);
            _gameView.Setup(gameView => gameView.DisplayGameOverMessage());

            var game = new Game(_grid.Object, _gameView.Object, _shipPlacementFactory.Object);

            // Act
            game.End();

            // Assert
            _gameView.Verify(gameView => gameView.DisplayGameOverMessage(), Times.Once());
        }

        [Test]
        public void GameIsNotOver_DoesNotDisplayGameOverMessage()
        {
            // Arrange
            _grid.Setup(grid => grid.ShipsArePlaced()).Returns(false);
            _grid.Setup(grid => grid.AllShipsAreSunk()).Returns(false);
            _gameView.Setup(gameView => gameView.DisplayGameOverMessage());

            var game = new Game(_grid.Object, _gameView.Object, _shipPlacementFactory.Object);

            // Act
            game.End();

            // Assert
            _gameView.Verify(gameView => gameView.DisplayGameOverMessage(), Times.Never());
        }
    }
}