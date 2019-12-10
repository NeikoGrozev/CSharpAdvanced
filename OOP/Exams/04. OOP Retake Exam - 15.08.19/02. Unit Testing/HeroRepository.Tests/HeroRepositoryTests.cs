using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    HeroRepository heros;
    Hero hero;

   [SetUp]
    public void Setup()
    {
        heros = new HeroRepository();

        string name = "Pesho";
        int level = 10;
        hero = new Hero(name, level);
    }

    [Test]
    public void CreateHero()
    {
        string name = "Pesho";
        int level = 10;
                
        Assert.AreEqual(name, hero.Name);
        Assert.AreEqual(level, hero.Level);
    }

    [Test]
    public void CreateHeroShouldBeThrowArgumentNullExceptionWithNullHero()
    {
        Hero hero = null;

        Assert.Throws<ArgumentNullException>(() => heros.Create(hero));
    }

    [Test]
    public void CreateHeroShouldBeThrowInvalidOprationExceptionWithSameHero()
    {
        heros.Create(hero);

        Assert.Throws<InvalidOperationException>(() => heros.Create(hero));
    }

    [Test]
    public void RemoveHeroShouldBeThrowArgumentNullExceptionWithNullHero()
    {
        string hero = null;

        Assert.Throws<ArgumentNullException>(() => heros.Remove(hero));
    }

    [Test]
    public void RemoveHeroShouldBeReturnTrue()
    {
        heros.Create(hero);
        bool isRemove = heros.Remove("Pesho");

        Assert.AreEqual(true, isRemove);
    }

    [Test]
    public void GetHeroWithHighestLevel()
    {
        heros.Create(hero);

        Hero heroTwo = new Hero("Ivan", 11);
        heros.Create(heroTwo);

        Assert.That(() => heros.GetHeroWithHighestLevel(), Is.EqualTo(heroTwo));
    }

    [Test]
    public void GetHeroReturnCorrectHero()
    {
        heros.Create(hero);

        Hero heroTwo = new Hero("Ivan", 11);
        heros.Create(heroTwo);

        Assert.That(() => heros.GetHero("Ivan"), Is.EqualTo(heroTwo));
    }
}