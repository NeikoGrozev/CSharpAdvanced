namespace BlueOrigin.Tests
{
    using NUnit.Framework;
    using System;

    public class SpaceshipTests
    {
        Spaceship spaceship;

        [SetUp]
        public void Setup()
        {
            string spaceshipName = "Apolo";
            int capacity = 10;
            this.spaceship = new Spaceship(spaceshipName, capacity);
        }

        [Test]
        public void CreateConstructorAstonaut()
        {
            string name = "Pesho";
            double oxygenInPercentage = 20d;
            Astronaut astronaut = new Astronaut(name, oxygenInPercentage);

            Assert.AreEqual(name, astronaut.Name);
            Assert.AreEqual(oxygenInPercentage, astronaut.OxygenInPercentage);
        }

        [Test]
        public void GetSpaceshipCountShouldBeCorrect()
        {
            string name = "Pesho";
            double oxygenInPercentage = 20d;
            Astronaut astronaut = new Astronaut(name, oxygenInPercentage);

            spaceship.Add(astronaut);

            Assert.AreEqual(1, spaceship.Count);
        }
       
        [Test]
        public void GetNameShouldBeCorrectName()
        {
            string spaceshipName = "Apolo";

            Assert.AreEqual(spaceshipName, spaceship.Name);
        }

        [Test]
        public void SetNameWithInvalidDataShouldBeThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Spaceship(null, 10));
        }

        [Test]
        public void GetCapacityShouldBeCorrectData()
        {
            int capacity = 10;

            Assert.AreEqual(capacity, spaceship.Capacity);
        }

        [Test]
        public void SetCapacityShouldBeThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Spaceship("Apolo", -1));
        }

        [Test]
        public void AddMoreAstronautsShouldBeThrowIvalidOperationException()
        {
            string name = "Pesho";
            double oxygenInPercentage = 20d;
            Astronaut astronaut = new Astronaut(name, oxygenInPercentage);

            string nameTwo = "Ivan";
            double oxygenInPercentageTwo = 50d;
            Astronaut astronautTwo = new Astronaut(nameTwo, oxygenInPercentageTwo);

            Spaceship spaceship = new Spaceship("Apolo", 1);

            spaceship.Add(astronaut);

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(astronautTwo));
        }

        [Test]
        public void AddSameAstronautShouldBeThrowInvalidOperationException()
        {
            string name = "Pesho";
            double oxygenInPercentage = 20d;
            Astronaut astronaut = new Astronaut(name, oxygenInPercentage);

            spaceship.Add(astronaut);

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(astronaut));
        }

        [Test]
        public void RemoveAstornautShoudBeCorrectTrue()
        {
            string name = "Pesho";
            double oxygenInPercentage = 20d;
            Astronaut astronaut = new Astronaut(name, oxygenInPercentage);

            spaceship.Add(astronaut);

            Assert.AreEqual(true, spaceship.Remove("Pesho"));
        }

    }
}