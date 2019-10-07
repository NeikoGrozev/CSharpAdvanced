namespace RawData
{
    public class Tire
    {
        public Tire(double tirePressure, int tireAge)
        {
            this.Pressure = tirePressure;
            this.Year = tireAge;
        }
        public double Pressure { get; set; }

        public int Year { get; set; }
    }
}
