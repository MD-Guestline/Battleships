using System.Text.RegularExpressions;
using Battleships.Factories;
using Battleships.Model;
using Battleships.View;

namespace Battleships
{
    public class Game
	{
        private readonly IGrid _grid;
		private readonly IGameView _gameView;
        private readonly IShipPlacementFactory _shipPlacementFactory;

		public Game(IGrid grid, IGameView gameView, IShipPlacementFactory shipPlacementFactory)
		{
			_grid = grid;
			_gameView = gameView;
            _shipPlacementFactory = shipPlacementFactory;
		}

        public void Start()
        {
            PlaceShipRandomly(ShipSize.Battleship);
            PlaceShipRandomly(ShipSize.Destroyer);
            PlaceShipRandomly(ShipSize.Destroyer);

            _gameView.DisplayGrid(_grid);
        }

        public void ProcessPlayerMove()
        {
            try
            {
                var playerMove = _gameView.GetPlayerMove();

                if (!IsValidNotation(playerMove))
                {
                    _gameView.DisplayErrorMessage("The coordinates provided were incorrectly formatted.");
                    return;
                }

                var column = char.ToUpper(playerMove[0]) - 'A';
                var row = int.Parse(playerMove.Substring(1)) - 1;

                _grid.ShootSquare(column, row);

                _gameView.DisplayGrid(_grid);
            }
            catch (ArgumentOutOfRangeException e)
            {
                _gameView.DisplayErrorMessage(e.Message);
            }
            catch (ArgumentException e)
            {
                _gameView.DisplayErrorMessage(e.Message);
            }
            catch (InvalidOperationException e)
            {
                _gameView.DisplayErrorMessage(e.Message);
            }
        }

        public bool IsOver()
        {
            return _grid.ShipsArePlaced() && _grid.AllShipsAreSunk();
        }

        public void End()
        {
            if (IsOver()) {
                _gameView.DisplayGameOverMessage();
            }
        }

        private void PlaceShipRandomly(ShipSize shipSize)
        {
            var ship = new Ship(shipSize);
            var shipPlacement = _shipPlacementFactory.CreateRandom(ship);

            while (!_grid.CanPlaceShip(ship, shipPlacement))
            {
                shipPlacement = _shipPlacementFactory.CreateRandom(ship);
            }

            _grid.PlaceShip(ship, shipPlacement);
        }

        private static bool IsValidNotation(string notation)
        {
            var a1NotationPattern = "^[A-Ja-j]([1-9]|10)$";
            var a1NotationRegex = new Regex(a1NotationPattern);

            return a1NotationRegex.IsMatch(notation);
        }
    }
}