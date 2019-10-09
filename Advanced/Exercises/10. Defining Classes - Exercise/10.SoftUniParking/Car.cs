namespace SoftUniParking
{
    using System.Text;

    public class Car
    {
        public Car()
        {
            this.Make = string.Empty;
            this.Model = string.Empty;
            this.HorsePower = 0;
            this.RegistrationNumber = string.Empty;
        }

        public Car(string make, string model, int horsePower, string registrationNumber)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = horsePower;
            this.RegistrationNumber = registrationNumber;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int HorsePower { get; set; }

        public string RegistrationNumber { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {Make}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"HorsePower: {HorsePower}");
            sb.Append($"RegistrationNumber: {RegistrationNumber}");

            return sb.ToString();
        }
    }
}
