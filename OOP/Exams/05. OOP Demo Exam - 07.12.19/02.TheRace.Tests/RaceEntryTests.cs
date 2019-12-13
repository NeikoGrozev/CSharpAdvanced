using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        UnitMotorcycle motorcycle;
        UnitRider rider;
        RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            string model = "Kawasaki";
            int horsePower = 100;
            double cubicCentimeters = 200;
            this.motorcycle = new UnitMotorcycle(model, horsePower, cubicCentimeters);

            string name = "Pesho";
            this.rider = new UnitRider(name, this.motorcycle);

            this.raceEntry = new RaceEntry();
        }

        [Test]
        public void CreateUnitMotorycleC()
        {
            string model = "Kawasaki";
            int horsePower = 100;
            double cubicCentimeters = 200;

            Assert.AreEqual(model, this.motorcycle.Model);
            Assert.AreEqual(horsePower, this.motorcycle.HorsePower);
            Assert.AreEqual(cubicCentimeters, this.motorcycle.CubicCentimeters);
        }

        [Test]
        public void CreateUnitRider()
        {
            string name = "Pesho";

            this.rider = new UnitRider(name, this.motorcycle);

            Assert.AreEqual(name, this.rider.Name);
        }

        [Test]
        public void CreateUnitRiderWithNameNullShouldBeThrowArgumentNullException()
        {
            string name = null;

            Assert.Throws<ArgumentNullException>(() => new UnitRider(name, this.motorcycle));
        }

        [Test]
        public void GEtCorrectMotorCycle()
        {
            string name = "Pesho";

            this.rider = new UnitRider(name, this.motorcycle);

            Assert.AreEqual(this.motorcycle, this.rider.Motorcycle);
        }

        [Test]
        public void AddRiderShouldBeCorrect()
        {

            Assert.That(() => this.raceEntry.AddRider(this.rider), Is.EqualTo("Rider Pesho added in race."));
        }

        [Test]
        public void AddRiderShouldBeThrowInvalidOperationExceptionWithNullName()
        {
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddRider(null));
        }

        [Test]
        public void AdDRiderShouldBeThrowInvalidOperationExceptionWithSameName()
        {
            this.raceEntry.AddRider(this.rider);

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddRider(this.rider));
        }

        [Test]
        public void GetCounter()
        {
            this.raceEntry.AddRider(this.rider);

            Assert.AreEqual(1, this.raceEntry.Counter);
        }

        [Test]
        public void CalculateAverageHorsePowerShouldBeReturnCorrectData()
        {
            this.raceEntry.AddRider(this.rider);

            string model = "BMW";
            int horsePower = 200;
            double cubicCentimeters = 300;
            var motorcycleTwo  = new UnitMotorcycle(model, horsePower, cubicCentimeters);

            string name = "Ivan";
            var riderTwo = new UnitRider(name, motorcycleTwo);

            this.raceEntry.AddRider(riderTwo);

            Assert.AreEqual(150, this.raceEntry.CalculateAverageHorsePower());

        }

        [Test]
        public void CalculateAverageHorsePowerShouldBeThrowInvalidOperationException()
        {
            this.raceEntry.AddRider(this.rider);

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());
        }        
    }
}