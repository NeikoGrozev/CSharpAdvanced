namespace CarSalesman
{
    public class Engine
    {
        public Engine()
        {
            this.Model = string.Empty;
            this.Power = string.Empty;
            this.Displacement = "n/a";
            this.Efficiency = "n/a";
        }

        public Engine(string model, string power)
            : this()
        {
            this.Model = model;
            this.Power = power;            
        }

        public Engine(string model, string power, int displacement)
            : this(model, power)
        {
            this.Displacement = displacement.ToString();
        }

        public Engine(string model, string power, string efficiency)
            : this(model, power)
        {
            this.Efficiency = efficiency;
        }

        public Engine(string model, string power, string displacemen, string efficiency)
            : this(model, power, efficiency)
        {
            this.Displacement = displacemen;
        }

        public string Model { get; set; }

        public string Power { get; set; }

        public string Displacement { get; set; }

        public string Efficiency { get; set; }
    }
}
