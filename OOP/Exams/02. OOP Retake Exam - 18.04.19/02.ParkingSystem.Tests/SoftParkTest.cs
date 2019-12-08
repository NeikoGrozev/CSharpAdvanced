namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        SoftPark softPark;

        [SetUp]
        public void Setup()
        {
            softPark = new SoftPark();
        }

        [Test]
        public void TestCarConstructor()
        {
            Car car = new Car("VW", "CA1234");

            Assert.AreEqual("VW", car.Make);
            Assert.AreEqual("CA1234", car.RegistrationNumber);
        }

        [Test]
        public void CreateSoftParkShouldBeCorrect()
        {
            Assert.DoesNotThrow(() => new SoftPark());
        }

        [Test]
        public void CreateSoftParkingWithCorrectParkingSpot()
        {
            Assert.AreEqual(12, softPark.Parking.Count);
        }

        [Test]
        public void ParkingCarShouldBeCorrect()
        {
            Car car = new Car("VW", "CA1234");
            string message = "Car:CA1234 parked successfully!";

            Assert.AreEqual(message, softPark.ParkCar("A1", car));
        }

        
        [Test]
        public void ParkCarShouldBeNotNeededTheSpodAndThrowArgumentException()
        {
            Car car = new Car("VW", "CA1234");

            Assert.Throws<ArgumentException>(() => softPark.ParkCar("N1", car));
        }

        [Test]
        public void ParkCarShouldBeThrowArgumentExceptionWithNotEmptySpot()
        {
            Car car = new Car("VW", "CA1234");
            softPark.ParkCar("A1", car);

            Car carTwo = new Car("Tesla", "CB7777");

            Assert.Throws<ArgumentException>(() => softPark.ParkCar("A1", carTwo));
        }

        [Test]
        public void ParkCarShouldBeThrowInvalidOperationExceptionWithAlredyParkingCar()
        {
            Car car = new Car("VW", "CA1234");
            softPark.ParkCar("A1", car);

            Assert.Throws<InvalidOperationException>(() => softPark.ParkCar("A2", car));
        }

        [Test]
        public void RemoveCarShouldBeCorrect()
        {
            Car car = new Car("VW", "CA1234");
            softPark.ParkCar("A1", car);
            string message = "Remove car:CA1234 successfully!";

            Assert.AreEqual(message, softPark.RemoveCar("A1", car));
        }

        [Test]
        public void RemoveCarShouldBeThrowArgumentExceptionWithInvalidParkingSpot()
        {
            Car car = new Car("VW", "CA1234");

            Assert.Throws<ArgumentException>(() => softPark.RemoveCar("H1", car));
        }

        [Test]
        public void REmoveCarShouldBeThrowArgumentExceptionWithInvalidCar()
        {
            Car car = new Car("VW", "CA1234");

            Assert.Throws<ArgumentException>(() => softPark.RemoveCar("A1", car));
        }
    }
}