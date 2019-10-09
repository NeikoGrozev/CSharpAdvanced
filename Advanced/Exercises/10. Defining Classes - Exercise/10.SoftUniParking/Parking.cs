namespace SoftUniParking
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    public class Parking
    {
        public int Count { get => this.cars.Count; }

        private List<Car> cars;

        private int capacity;

        public Parking()
        {
            this.cars = new List<Car>();
            this.capacity = 0;
        }

        public Parking(int capacity)
            : this()
        {
            this.capacity = capacity;
        }

        public List<Car> Cars { get; }

        public int Capacity { get; set; }

        public string AddCar(Car car)
        {
            if (this.cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (cars.Count == capacity)
            {
                return "Parking is full!";
            }
            else
            {
                this.cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string registrationNumber)
        {
            if (cars.Any(x => x.RegistrationNumber == registrationNumber))
            {
                this.cars.Remove(this.cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber));

                return $"Successfully removed { registrationNumber}";
            }
            else
            {
                return $"Car with that registration number, doesn't exist!";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return this.cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var carNumber in registrationNumbers)
            {
                this.cars.RemoveAll(x => x.RegistrationNumber == carNumber);
            }
        }
    }
}
