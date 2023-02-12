using Battleships.Model;

namespace Battleships.Tests.Model.GridTests
{
    [TestFixture]
	public class ShootSquare
	{
        [TestCase(-1, 0)]
        [TestCase(10, 0)]
        [TestCase(0, -1)]
        [TestCase(0, 10)]
        public void CoordinatesAreOutOfRange_ThrowsArgumentOutOfRangeException(int columnIndex, int rowIndex)
		{
            // Arrange
            var grid = new Grid();

            // Act
			void result() => grid.ShootSquare(columnIndex, rowIndex);

            // Assert
            Assert.That(result, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [TestCase(0, 0)]
        [TestCase(4, 4)]
        [TestCase(9, 9)]
        [TestCase(9, 0)]
        [TestCase(4, 9)]
        [TestCase(0, 4)]
        public void CoordinatesAreInRange_ShootsSquareAtExpectedCoordinates(int column, int row)
        {
            // Arrange
            var grid = new Grid();
            var expectedSquare = grid.GetSquare(column, row);
            var squareIsShotBefore = expectedSquare.IsShot;

            // Act
            grid.ShootSquare(column, row);

            // Assert
            Assert.That(squareIsShotBefore, Is.False);
            Assert.That(expectedSquare.IsShot, Is.True);
        }
	}
}