using System.Xml.Schema;

namespace Ferrari
{
    public class Ferrari : ICar
    {
        private const string model = "488-Spider";
        private const string breaks = "Brakes!";
        private const string gasPedal = "Gas!";

        public Ferrari(string driver)
        {
            this.Model = model;
            this.Breaks = breaks;
            this.GasPedal = gasPedal;
            this.Driver = driver;
        }

        public string Model { get; set; }
        public string Breaks { get; set; }
        public string GasPedal { get; set; }
        public string Driver { get; set; }

        public override string ToString()
        {
            return $"{this.Model}/{this.Breaks}/{this.GasPedal}/{this.Driver}";
        }
    }
}