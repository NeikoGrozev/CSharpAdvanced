using NUnit.Framework;
using System;

public class DummyTests
{
    [Test]
    public void DummyLosesHealthIfAttacked()
    {
        Dummy dummy = new Dummy(10, 10);

        dummy.TakeAttack(5);

        Assert.That(dummy.Health, Is.EqualTo(5));
    }

    [Test]
    public void DeadDummyThrowsInvalidOperationExceptionIfAttacked()
    {
        Dummy dummy = new Dummy(0, 10);        

        Assert.That(() => dummy.TakeAttack(10), Throws.InvalidOperationException);
    }
   
    [Test]
    public void DeadDummyCanGivenExperience()
    {
        Dummy dummy = new Dummy(0, 10);

        Assert.That(() => dummy.GiveExperience(), Is.EqualTo(10));
    }

    [Test]
    public void DummyCantGiveExperianceThrowInvalidOperationExeption()
    {
        Dummy dummy = new Dummy(10, 10);

        Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
    }
}