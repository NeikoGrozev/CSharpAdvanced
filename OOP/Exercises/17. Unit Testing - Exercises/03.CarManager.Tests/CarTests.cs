namespace Tests
{
    using CarManager;
    using NUnit.Framework;
    using System;

    public class CarTests
    {
        [Test]
        public void ObjectIsCorrectMakeWithCorrectData()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 50;

            Assert.DoesNotThrow(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void GetMakeShouldBeCorrectData()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 50;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(make, car.Make);
        }

        [Test]
        public void SetMakeShouldBeThrowArgumentException()
        {
            string make = "";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 50;

            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void GetModelShouldBeCorrectData()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 50;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(model, car.Model);
        }

        [Test]
        public void SetModelShouldBeThrowArgumentException()
        {
            string make = "VW";
            string model = null;
            double fuelConsumption = 2;
            double fuelCapacity = 50;

            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void GetFuelConcumptionMakeShouldBeCorrectData()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 50;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
        }

        [Test]
        public void SetFuelConsumptinShouldBeThrowArgumentException()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = -10;
            double fuelCapacity = 50;

            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void GetFuelCapacityMakeShouldBeCorrectData()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 50;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [Test]
        public void SetFuelCapacityShouldBeThrowArgumentException()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = -50;

            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void RefuelMethodInCorrrectData()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 50;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(10);

            Assert.AreEqual(10, car.FuelAmount);
        }

        [Test]
        public void RefuelMethodWithZero()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 8;
            double fuelCapacity = 50;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(() => car.Refuel(0));            
        }

        [Test]
        public void RefuelMethodWithMoreLessFuelCapacity()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 50;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(60);

            Assert.AreEqual(fuelCapacity, car.FuelAmount);
        }

        [Test]
        public void RefuelShouldBeThrowArgumentExceptionWhitNegativeData()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 50;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(() => car.Refuel(-10));
        }

        [Test]
        public void DriveMethodWithCorrectDistance()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 8;
            double fuelCapacity = 50;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(10);
            car.Drive(100);

            Assert.AreEqual(2, car.FuelAmount);
        }

        [Test]
        public void DriveShouldBeThrowInvalidOperationExceptionWhitBigDistance()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 8;
            double fuelCapacity = 50;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(10);

            Assert.Throws<InvalidOperationException>(() => car.Drive(500));
        }
    }
}