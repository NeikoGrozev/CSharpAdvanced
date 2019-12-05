namespace Tests
{
    using FightingArena;
    using NUnit.Framework;
    using System;

    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void GetEmptyConstuctor()
        {
            Assert.DoesNotThrow(() => new Arena());
        }

        [Test]
        public void GetArenaCount()
        {
            Assert.AreEqual(0, this.arena.Count);
        }

        [Test]
        public void EnrollMethodWithCorrectData()
        {
            string name = "Pesho";
            int damage = 10;
            int hp = 10;
            Warrior warrior = new Warrior(name, damage, hp);

            this.arena.Enroll(warrior);

            Assert.AreEqual(1, this.arena.Count);
        }

        [Test]
        public void EnrollMethodWithSomeNameShouldBeThrowInvalidOperagionException()
        {
            string name = "Pesho";
            int damage = 10;
            int hp = 10;
            Warrior warrior = new Warrior(name, damage, hp);

            this.arena.Enroll(warrior);

            Warrior anotherWarrior = new Warrior("Pesho", 20, 20);

            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(anotherWarrior));
        }

        [Test]
        public void FightMethodShouldBeCorrectInput()
        {
            Warrior warrior = new Warrior("Pesho", 40, 140);
            Warrior anotherWarrior = new Warrior("Gosho", 100, 100);

            this.arena.Enroll(warrior);
            this.arena.Enroll(anotherWarrior);
            this.arena.Fight(warrior.Name, anotherWarrior.Name);

            Assert.That(warrior.HP, Is.EqualTo(40));
        }

        [Test]
        public void FightMethodShouldBeThrowInvalidOperationExceptionWithAttackerNameNull()
        {
            Warrior warrior = new Warrior("Pesho", 40, 140);
            Warrior anotherWarrior = new Warrior("Gosho", 100, 100);

            this.arena.Enroll(anotherWarrior);

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight(warrior.Name, anotherWarrior.Name));
        }
    }
}