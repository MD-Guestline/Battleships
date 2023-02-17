using Battleships.Model;

namespace Battleships.Tests.Model.GridTests
{
    [TestFixture]
    public class CanPlaceShip
    {
        [TestCase(-1, 0)]
        [TestCase(10, 0)]
        [TestCase(0, -1)]
        [TestCase(0, 10)]
        public void CoordinatesAreOutOfRange_ThrowsArgumentOutOfRangeException(int startColumn, int startRow)
        {
            // Arrange
            var grid = new Grid();
            var ship = new Ship(ShipSize.Battleship);
            var shipPlacement = new ShipPlacement(Orientation.Horizontal, startColumn, startRow);

            // Act
            void result() => grid.CanPlaceShip(ship, shipPlacement);

            // Assert
            Assert.That(result, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [TestCaseSource(nameof(ShipOutOfBoundsTestCases))]
        public void ShipOutOfBounds_ReturnsFalse(Ship ship, ShipPlacement shipPlacement)
        {
            // Arrange
            var grid = new Grid();

            // Act
            var result = grid.CanPlaceShip(ship, shipPlacement);

            // Assert
            Assert.That(result, Is.False);
        }

        [TestCaseSource(nameof(ShipOverlapsWithAlreadyPlacedShipTestCases))]
        public void ShipOverlapsWithAlreadyPlacedShip_ReturnsFalse(Ship existingShip, ShipPlacement existingPlacement, Ship newShip, ShipPlacement newPlacement)
        {
            // Arrange
            var grid = new Grid();
            grid.PlaceShip(existingShip, existingPlacement);

            // Act
            var result = grid.CanPlaceShip(newShip, newPlacement);

            // Assert
            Assert.That(result, Is.False);
        }

        [TestCaseSource(nameof(ShipDoesNotOverlapTestCases))]
        public void ShipDoesNotOverlap_ReturnsTrue(Ship existingShip, ShipPlacement existingPlacement, Ship newShip, ShipPlacement newPlacement)
        {
            // Arrange
            var grid = new Grid();
            grid.PlaceShip(existingShip, existingPlacement);

            // Act
            var result = grid.CanPlaceShip(newShip, newPlacement);

            // Assert
            Assert.That(result, Is.True);
        }

        public static IEnumerable<TestCaseData> ShipOutOfBoundsTestCases
        {
            get
            {
                yield return new TestCaseData(new Ship(ShipSize.Destroyer), new ShipPlacement(Orientation.Vertical, 0, 9)).SetName("VerticalDestroyerStartsOnLastColumn_ReturnsFalse");
                yield return new TestCaseData(new Ship(ShipSize.Destroyer), new ShipPlacement(Orientation.Vertical, 0, 7)).SetName("VerticalDestroyerEndsOutsideLastColumn_ReturnsFalse");
                yield return new TestCaseData(new Ship(ShipSize.Destroyer), new ShipPlacement(Orientation.Horizontal, 9, 0)).SetName("HorizontalDestroyerStartsOnLastRow_ReturnsFalse");
                yield return new TestCaseData(new Ship(ShipSize.Destroyer), new ShipPlacement(Orientation.Horizontal, 7, 0)).SetName("HorizontalDestroyerEndsOutsideLastRow_ReturnsFalse");
                yield return new TestCaseData(new Ship(ShipSize.Battleship), new ShipPlacement(Orientation.Vertical, 0, 9)).SetName("VerticalBattleshipStartsOnLastColumn_ReturnsFalse");
                yield return new TestCaseData(new Ship(ShipSize.Battleship), new ShipPlacement(Orientation.Vertical, 0, 6)).SetName("VerticalBattleshipEndsOutsideLastColumn_ReturnsFalse");
                yield return new TestCaseData(new Ship(ShipSize.Battleship), new ShipPlacement(Orientation.Horizontal, 9, 0)).SetName("HorizontalBattleshipStartsOnLastRow_ReturnsFalse");
                yield return new TestCaseData(new Ship(ShipSize.Battleship), new ShipPlacement(Orientation.Horizontal, 6, 0)).SetName("HorizontalBattleshipEndsOutsideRow_ReturnsFalse");
            }
        }

        public static IEnumerable<TestCaseData> ShipOverlapsWithAlreadyPlacedShipTestCases
        {
            get
            {
                yield return new TestCaseData(new Ship(ShipSize.Destroyer), new ShipPlacement(Orientation.Horizontal, 0, 0), new Ship(ShipSize.Destroyer), new ShipPlacement(Orientation.Horizontal, 0, 0)).SetName("NewHorizontalDestroyerStartsInSamePlaceAsHorizontalDestroyerStarts_ReturnsFalse");
                yield return new TestCaseData(new Ship(ShipSize.Destroyer), new ShipPlacement(Orientation.Horizontal, 0, 0), new Ship(ShipSize.Battleship), new ShipPlacement(Orientation.Vertical, 0, 0)).SetName("NewVerticalBattleshipStartsInSamePlaceAsHorizontalDestroyerStarts_ReturnsFalse");
                yield return new TestCaseData(new Ship(ShipSize.Battleship), new ShipPlacement(Orientation.Horizontal, 0, 0), new Ship(ShipSize.Destroyer), new ShipPlacement(Orientation.Horizontal, 4, 0)).SetName("NewHorizontalDestroyerStartsInSameAsPlaceHorizontalBattleshipEnds_ReturnsFalse");
                yield return new TestCaseData(new Ship(ShipSize.Battleship), new ShipPlacement(Orientation.Horizontal, 2, 4), new Ship(ShipSize.Battleship), new ShipPlacement(Orientation.Vertical, 5, 0)).SetName("NewVerticalBattleshipIntersectsHorizontalBattleship_ReturnsFalse");
                yield return new TestCaseData(new Ship(ShipSize.Destroyer), new ShipPlacement(Orientation.Vertical, 0, 0), new Ship(ShipSize.Destroyer), new ShipPlacement(Orientation.Vertical, 0, 0)).SetName("NewVerticalDestroyerStartsInSamePlaceAsVerticalDestroyerStarts_ReturnsFalse");
                yield return new TestCaseData(new Ship(ShipSize.Destroyer), new ShipPlacement(Orientation.Vertical, 0, 0), new Ship(ShipSize.Battleship), new ShipPlacement(Orientation.Horizontal, 0, 0)).SetName("NewHorizontalBattleshipStartsInSamePlaceAsVerticalDestroyerStarts_ReturnsFalse");
                yield return new TestCaseData(new Ship(ShipSize.Battleship), new ShipPlacement(Orientation.Vertical, 0, 0), new Ship(ShipSize.Destroyer), new ShipPlacement(Orientation.Vertical, 0, 4)).SetName("NewVerticalDestroyerStartsInSamePlaceAsVerticalBattleshipEnds_ReturnsFalse");
                yield return new TestCaseData(new Ship(ShipSize.Battleship), new ShipPlacement(Orientation.Vertical, 4, 2), new Ship(ShipSize.Battleship), new ShipPlacement(Orientation.Horizontal, 0, 5)).SetName("NewHorizontalBattleshipIntersectsVerticalBattleship_ReturnsFalse");
            }
        }

        public static IEnumerable<TestCaseData> ShipDoesNotOverlapTestCases
        {
            get
            {
                yield return new TestCaseData(new Ship(ShipSize.Destroyer), new ShipPlacement(Orientation.Horizontal, 0, 0), new Ship(ShipSize.Destroyer), new ShipPlacement(Orientation.Horizontal, 4, 0)).SetName("NewHorizontalDestroyerStartsAfterHorizontalDestroyer_ReturnsTrue");
                yield return new TestCaseData(new Ship(ShipSize.Destroyer), new ShipPlacement(Orientation.Horizontal, 0, 0), new Ship(ShipSize.Battleship), new ShipPlacement(Orientation.Vertical, 4, 0)).SetName("NewVerticalBattleshipPlacedInFrontOfHorizontalDestroyer_ReturnsTrue");
                yield return new TestCaseData(new Ship(ShipSize.Battleship), new ShipPlacement(Orientation.Horizontal, 4, 0), new Ship(ShipSize.Destroyer), new ShipPlacement(Orientation.Horizontal, 0, 0)).SetName("NewHorizontalDestroyerEndsBeforeHorizontalBattleship_ReturnsTrue");
                yield return new TestCaseData(new Ship(ShipSize.Battleship), new ShipPlacement(Orientation.Horizontal, 2, 2), new Ship(ShipSize.Battleship), new ShipPlacement(Orientation.Vertical, 0, 1)).SetName("NewVerticalBattleshipPlacedBehindHorizontalBattleship_ReturnsTrue");
                yield return new TestCaseData(new Ship(ShipSize.Destroyer), new ShipPlacement(Orientation.Vertical, 0, 0), new Ship(ShipSize.Destroyer), new ShipPlacement(Orientation.Vertical, 0, 4)).SetName("NewVerticalDestroyerStartsAfterVerticalDestroyer_ReturnsTrue");
                yield return new TestCaseData(new Ship(ShipSize.Destroyer), new ShipPlacement(Orientation.Vertical, 0, 0), new Ship(ShipSize.Battleship), new ShipPlacement(Orientation.Horizontal, 0, 4)).SetName("NewHorizontalBattleshipPlacedBelowVerticalDestroyer_ReturnsTrue");
                yield return new TestCaseData(new Ship(ShipSize.Battleship), new ShipPlacement(Orientation.Vertical, 0, 4), new Ship(ShipSize.Destroyer), new ShipPlacement(Orientation.Vertical, 0, 0)).SetName("NewVerticalDestroyerEndsBeforeVerticalBattleship_ReturnsTrue");
                yield return new TestCaseData(new Ship(ShipSize.Battleship), new ShipPlacement(Orientation.Vertical, 2, 2), new Ship(ShipSize.Battleship), new ShipPlacement(Orientation.Horizontal, 1, 0)).SetName("NewHorizontalBattleshipPlacedAboveVerticalBattleship_ReturnsTrue");
            }
        }
    }
}