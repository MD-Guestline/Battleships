using Battleships.Factories;
using Battleships.Model;
using Battleships.View;
using Moq;

namespace Battleships.Tests.GameTests
{
    [TestFixture]
	public class Start
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
        public void WhenCalled_PlacesBattleshipAndTwoDestroyers()
        {
            // Arrange
            var placedShips = new List<IShip>();
            _grid.Setup(grid => grid.CanPlaceShip(It.IsAny<IShip>(), It.IsAny<ShipPlacement>()))
                .Returns(true);
            _grid.Setup(grid => grid.PlaceShip(It.IsAny<IShip>(), It.IsAny<ShipPlacement>()))
                .Callback((IShip ship, ShipPlacement shipPlacement) => placedShips.Add(ship));
            _shipPlacementFactory.Setup(factory => factory.CreateRandom(It.IsAny<IShip>()))
                .Returns(new ShipPlacement(Orientation.Horizontal, 0, 0));

            var game = new Game(_grid.Object, _gameView.Object, _shipPlacementFactory.Object);

            // Act
            game.Start();

            // Assert
            Assert.That(placedShips, Has.Count.EqualTo(3));
            Assert.That(placedShips, Has.Exactly(2).With.Property(nameof(IShip.Size)).EqualTo((int)ShipSize.Destroyer));
            Assert.That(placedShips, Has.Exactly(1).With.Property(nameof(IShip.Size)).EqualTo((int)ShipSize.Battleship));
        }

        [Test]
        public void WhenCalled_DisplaysGrid()
        {
            // Arrange
            _grid.Setup(grid => grid.CanPlaceShip(It.IsAny<IShip>(), It.IsAny<ShipPlacement>()))
                .Returns(true);
            _gameView.Setup(gameView => gameView.DisplayGrid(It.IsAny<IGrid>()));
            _shipPlacementFactory.Setup(factory => factory.CreateRandom(It.IsAny<IShip>()))
                .Returns(new ShipPlacement(Orientation.Horizontal, 0, 0));

            var game = new Game(_grid.Object, _gameView.Object, _shipPlacementFactory.Object);

            // Act
            game.Start();

            // Assert
            _gameView.Verify(gameView => gameView.DisplayGrid(It.IsAny<IGrid>()), Times.Once);
        }

        [Test]
        public void ShipCannotBePlacedWithCurrentShipPlacement_CreatesNewRandomShipPlacement()
        {
            // Arrange
            _grid.SetupSequence(grid => grid.CanPlaceShip(It.IsAny<IShip>(), It.IsAny<ShipPlacement>()))
                .Returns(true)
                .Returns(true)
                .Returns(false)
                .Returns(true);
            _shipPlacementFactory.Setup(factory => factory.CreateRandom(It.IsAny<IShip>()))
                .Returns(new ShipPlacement(Orientation.Horizontal, 0, 0));

            var game = new Game(_grid.Object, _gameView.Object, _shipPlacementFactory.Object);

            // Act
            game.Start();

            // Assert
            _shipPlacementFactory.Verify(factory => factory.CreateRandom(It.IsAny<IShip>()), Times.Exactly(4));
        }
    }
}