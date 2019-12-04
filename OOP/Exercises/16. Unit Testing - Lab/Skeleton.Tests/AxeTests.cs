using NUnit.Framework;

public class AxeTests
{
    [Test]
    public void TestIfWeaponLosesDurabilityAfterachAttack()
    {
        Axe axe = new Axe(10, 10);
        Dummy dummy = new Dummy(10, 10);

        axe.Attack(dummy);

        Assert.That(axe.DurabilityPoints, Is.EqualTo(9));
    }

    [Test]
    public void TestAttackingWithABrokenWeapon()
    {
        Axe axe = new Axe(10, 0);
        Dummy dummy = new Dummy(10, 10);

        Assert.That(() => axe.Attack(dummy),
             Throws.InvalidOperationException
             .With.Message.EqualTo("Axe is broken."));
    }
}