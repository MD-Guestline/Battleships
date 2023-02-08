using System;
using Battleships.Model;

namespace Battleships.Tests.Model.ShipTests
{
	public class IsSunk
	{
		[Test]
		public void IsSunk_HealthIsZero_ReturnsTrue()
		{
			var ship = new Ship(1);
			ship.Hit();

			var result = ship.IsSunk();

			Assert.That(ship.Health, Is.EqualTo(0));
			Assert.That(result, Is.True);
		}

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void IsSunk_HealthIsGreaterThanZero_ReturnsFalse(int size)
        {
            var ship = new Ship(size);

            var result = ship.IsSunk();

            Assert.That(result, Is.False);
        }
    }
}

