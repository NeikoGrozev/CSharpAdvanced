namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        Fish fish;
        Aquarium aquarium;

        [SetUp]
        public void Setup()
        {
            string name = "Pesho";
            this.fish = new Fish(name);

            string nameAquarium = "See";
            int capacity = 10;
            this.aquarium = new Aquarium(nameAquarium, capacity);
        }

        [Test]
        public void CreateFish()
        {
            string currentName = "Pesho";
            bool available = true;

            Assert.That(this.fish.Name, Is.EqualTo(currentName));
            Assert.AreEqual(available, this.fish.Available);
        }

        [Test]
        public void GetNameShouldBeCorrect()
        {
            string name = "See";

            Assert.AreEqual(name, this.aquarium.Name);
        }

        [Test]
        public void SetNameShoudBeThrowArgumentNullException()
        {
            string name = null;
            int capacity = 10;

            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, capacity));
        }

        [Test]
        public void GetCapacityShouldBeCorrect()
        {
            int capacity = 10;

            Assert.AreEqual(capacity, this.aquarium.Capacity);
        }

        [Test]
        public void SetCapacityShouldBeThrowArgumentException()
        {
            string name = "See";
            int capacity = -1;

            Assert.Throws<ArgumentException>(() => new Aquarium(name, capacity));
        }

        [Test]
        public void GetCountShouldBeREturnCorrectValue()
        {
            Assert.AreEqual(0, this.aquarium.Count);
        }

        [Test]
        public void AddFishShouldBeCorrect()
        {
            this.aquarium.Add(this.fish);

            Assert.AreEqual(1, this.aquarium.Count);
        }

        [Test]
        public void AddFishShouldBeThrowInvalidOperationException()
        {
            Aquarium aquarium = new Aquarium("BlackSee", 1);
            aquarium.Add(this.fish);

            Fish anotherFish = new Fish("Ivan");

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(anotherFish));
        }

        [Test]
        public void RemoveFishShouldBeCorrect()
        {
            this.aquarium.Add(this.fish);
            this.aquarium.RemoveFish("Pesho");

            Assert.AreEqual(0, this.aquarium.Count);
        }

        [Test]
        public void REmoveFishShouldBEthrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => this.aquarium.RemoveFish("Ivan"));
        }
       
        [Test]
        public void SellFishShouldBeCorrect()
        {
            this.aquarium.Add(this.fish);

            Assert.That(() => this.aquarium.SellFish("Pesho"), Is.EqualTo(this.fish));
        }

        [Test]
        public void SellFishShouldBeThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => this.aquarium.SellFish("Ivan"));
        }

        [Test]
        public void Report()
        {
            this.aquarium.Add(this.fish);

            Assert.AreEqual($"Fish available at See: Pesho", this.aquarium.Report());
        }
    }
}
