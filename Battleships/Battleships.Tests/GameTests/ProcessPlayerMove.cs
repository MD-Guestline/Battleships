using Battleships.Factories;
using Battleships.Model;
using Battleships.View;
using Moq;

namespace Battleships.Tests.GameTests
{
    [TestFixture]
    public class ProcessPlayerMove
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

        [TestCase(" ")]
        [TestCase(" 1")]
        [TestCase("A")]
        [TestCase("A ")]
        [TestCase("A 1")]
        [TestCase("AA1")]
        [TestCase("K1")]
        [TestCase("Z1")]
        [TestCase("@1")]
        [TestCase("あ1")]
        [TestCase("A0")]
        [TestCase("A11")]
        [TestCase("A01")]
        public void ReceivesInvalidPlayerMove_DisplaysIncorrectCoordinatesErrorMessage(string invalidPlayerMove)
        {
            // Arrange
            var expectedErrorMessage = "The coordinates provided were incorrectly formatted.";
            string? displayedErrorMessage = null;
            _gameView.Setup(gameView => gameView.GetPlayerMove())
                .Returns(invalidPlayerMove);
            _gameView.Setup(gameView => gameView.DisplayErrorMessage(It.IsAny<string>()))
                .Callback<string>(errorMessage => displayedErrorMessage = errorMessage);

            var game = new Game(_grid.Object, _gameView.Object, _shipPlacementFactory.Object);

            // Act
            game.ProcessPlayerMove();

            // Assert
            Assert.That(displayedErrorMessage, Is.EqualTo(expectedErrorMessage));
        }

        [TestCase("A1", 0, 0)]
        [TestCase("E5", 4, 4)]
        [TestCase("J10", 9, 9)]
        [TestCase("j1", 9, 0)]
        [TestCase("e10", 4, 9)]
        [TestCase("a5", 0, 4)]
        public void ReceivesValidPlayerMove_ShootSquareOnGridWithExpectedCoordinates(string validPlayerMove, int expectedColumn, int expectedRow)
        {
            // Arrange
            int? columnShot = null;
            int? rowShot = null;
            _gameView.Setup(gameView => gameView.GetPlayerMove())
                .Returns(validPlayerMove);
            _grid.Setup(grid => grid.ShootSquare(It.IsAny<int>(), It.IsAny<int>()))
                .Callback((int column, int row) =>
                {
                    columnShot = column;
                    rowShot = row;
                });

            var game = new Game(_grid.Object, _gameView.Object, _shipPlacementFactory.Object);

            // Act
            game.ProcessPlayerMove();

            // Assert
            Assert.That(columnShot, Is.EqualTo(expectedColumn));
            Assert.That(rowShot, Is.EqualTo(expectedRow));
        }

        [TestCase("A1")]
        [TestCase("E5")]
        [TestCase("J10")]
        [TestCase("j1")]
        [TestCase("e10")]
        [TestCase("a5")]
        public void ReceivesValidPlayerMove_RedrawsGrid(string validPlayerMove)
        {
            // Arrange
            _gameView.Setup(gameView => gameView.GetPlayerMove())
                .Returns(validPlayerMove);
            _gameView.Setup(gameView => gameView.DisplayGrid(It.IsAny<IGrid>()));

            var game = new Game(_grid.Object, _gameView.Object, _shipPlacementFactory.Object);

            // Act
            game.ProcessPlayerMove();

            // Assert
            _gameView.Verify(gameView => gameView.DisplayGrid(It.IsAny<IGrid>()), Times.Once);
        }
    }
}