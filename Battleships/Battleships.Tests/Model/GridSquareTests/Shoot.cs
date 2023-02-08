using System;
using Battleships.Model;
using Moq;

namespace Battleships.Tests.Model.GridSquareTests
{
	public class Shoot
	{
        [Test]
        public void Shoot_HasAlreadyBeenAttacked_ThrowsInvalidOperationException()
        {
            var gridSquare = new GridSquare();
            gridSquare.Shoot();

            void result() => gridSquare.Shoot();

            Assert.That(result, Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
		public void Shoot_HasNotBeenAttacked_GridSquareBecomesAttacked()
		{
			var gridSquare = new GridSquare();

			gridSquare.Shoot();

			Assert.That(gridSquare.IsAttacked, Is.True);
		}

        [Test]
        public void Shoot_HasAShip_CallsHitOnShip()
        {
            var gridSquare = new GridSquare();
            var mockShip = new Mock<IShip>();
            gridSquare.Ship = mockShip.Object;

            gridSquare.Shoot();

            mockShip.Verify(ship => ship.Hit(), Times.Once);
        }
    }
}

