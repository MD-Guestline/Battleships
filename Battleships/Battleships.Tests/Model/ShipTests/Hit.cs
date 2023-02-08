using Battleships.Model;

namespace Battleships.Tests.Model.ShipTests;

public class Hit
{
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    public void Hit_HealthIsOneOrMore_HealthIsDecreasedByOne(int size)
    {
        var ship = new Ship(size);
        var healthBeforeHit = ship.Health;

        ship.Hit();

        Assert.That(ship.Health, Is.EqualTo(healthBeforeHit - 1));
    }

    [Test]
    public void Hit_HealthIsZero_HealthRemainsZero()
    {
        var ship = new Ship(1);
        ship.Hit();
        var healthBeforeHit = ship.Health;

        ship.Hit();

        Assert.That(healthBeforeHit, Is.EqualTo(0));
        Assert.That(ship.Health, Is.EqualTo(0));
    }

}
