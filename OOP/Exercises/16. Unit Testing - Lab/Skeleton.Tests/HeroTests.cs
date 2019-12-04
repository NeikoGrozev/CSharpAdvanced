using NUnit.Framework;
using Skeleton.Contracts;

[TestFixture]
public class HeroTests
{
    [Test]
    public void Test1()
    {
        IWeapon weapon = new Axe(10, 10);
        ITarget target = new Dummy(10, 10);

        Hero hero = new Hero("Pesho", weapon);

        hero.Attack(target);

        Assert.That(hero.Experience, Is.EqualTo(10));
    }
}