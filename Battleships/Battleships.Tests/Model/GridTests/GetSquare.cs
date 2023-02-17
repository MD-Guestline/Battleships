using Battleships.Model;

namespace Battleships.Tests.Model.GridTests
{
    [TestFixture]
    public class GetSquare
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
            void result() => grid.GetSquare(columnIndex, rowIndex);

            // Assert
            Assert.That(result, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
    }
}