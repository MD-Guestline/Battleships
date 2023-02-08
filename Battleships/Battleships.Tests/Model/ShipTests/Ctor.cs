using System;
using Battleships.Model;

namespace Battleships.Tests.Model.ShipTests
{
	public class Ctor
	{
		[TestCase(0)]
		[TestCase(-1)]
		public void Constructor_SizeIsLessThanOne_ThrowsArgumentOutOfRangeException(int size)
		{
			void result() => new Ship(size);

			Assert.That(result, Throws.InstanceOf<ArgumentOutOfRangeException>());
		}

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void Constructor_SizeIsOneOrMore_ShipHealthIsEqualToSize(int size)
        {
            var ship = new Ship(size);

            Assert.That(ship.Health, Is.EqualTo(size));
        }
    }
}

