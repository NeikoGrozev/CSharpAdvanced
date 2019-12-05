namespace Tests
{
    using FightingArena;
    using NUnit.Framework;
    using System;

    public class WarriorTests
    {
        [Test]
        public void GetConstructorWithCorrectData()
        {
            string name = "Pesho";
            int damage = 10;
            int hp = 10;

            Assert.DoesNotThrow(() =>
            {
                Warrior warrior = new Warrior(name, damage, hp);
            });
        }

        [Test]
        public void GetNameWithCorrectData()
        {
            string name = "Pesho";
            int damage = 10;
            int hp = 10;

            Warrior warrior = new Warrior(name, damage, hp);

            Assert.AreEqual(name, warrior.Name);
        }

        [Test]
        public void SetNameShouldBeThrowArgumentExceptionWithIncorrectData()
        {
            string name = null;
            int damage = 10;
            int hp = 10;

            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        public void GetDamageWithCorrectData()
        {
            string name = "Pesho";
            int damage = 10;
            int hp = 10;

            Warrior warrior = new Warrior(name, damage, hp);

            Assert.AreEqual(damage, warrior.Damage);
        }

        [Test]
        public void SetDamageShouldBeThrowArgumentExceptionWithIncorrectData()
        {
            string name = "Pesho";
            int damage = 0;
            int hp = 10;

            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        public void GetHPWithCorrectData()
        {
            string name = "Pesho";
            int damage = 10;
            int hp = 10;

            Warrior warrior = new Warrior(name, damage, hp);

            Assert.AreEqual(hp, warrior.HP);
        }

        [Test]
        public void SetHPShouldBeThrowArgumentExceptionWithIncorrectData()
        {
            string name = "Pesho";
            int damage = 10;
            int hp = -1;

            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        public void AttackMethodShouldBeThrowInvalidOperationExceptionWithLowHpOfAttacker()
        {
            Warrior attacker = new Warrior("Pesho", 10, 10);
            Warrior difender = new Warrior("Gosho", 10, 40);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(difender));
        }

        [Test]
        public void AttackMethodShouldBeThrowInvalidOperationExceptionWithLowHpOfDefender()
        {
            Warrior attacker = new Warrior("Pesho", 10, 40);
            Warrior defender = new Warrior("Gosho", 10, 10);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void AttackMethodShouldBeThrowInvalidOperationExceptionWithLowHpOfAttackerToDefender()
        {
            Warrior attacker = new Warrior("Pesho", 10, 40);
            Warrior defender = new Warrior("Gosho", 50, 50);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void AttackMethodWithMoreDamageOfDefender()
        {
            Warrior attacker = new Warrior("Pesho", 100, 100);
            Warrior defender = new Warrior("Gosho", 60, 50);

            attacker.Attack(defender);

            Assert.That(defender.HP == 0);
        }

        [Test]
        public void AttackMethodWithLessDamageOfDefender()
        {
            Warrior attacker = new Warrior("Pesho", 40, 140);
            Warrior defender = new Warrior("Gosho", 100, 100);

            attacker.Attack(defender);

            Assert.That(defender.HP == 60);
        }
    }
}