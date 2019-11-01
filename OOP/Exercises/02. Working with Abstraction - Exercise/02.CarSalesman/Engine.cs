namespace CarSalesman
{
    using System.Text;

    public class Engine
    {
        private const string offset = "  ";
        private const int defaultDisplacement = -1;
        private const string defaultEfficiency = "n/a";

        private int power;
        private int displacement;
        private string efficiency;

        public Engine(string model, int power)
        {
            this.Model = model;
            this.power = power;
            this.displacement = defaultDisplacement;
            this.efficiency = defaultEfficiency;
        }

        public Engine(string model, int power, int displacement)
            : this(model, power)
        {
            this.displacement = displacement;
            this.efficiency = defaultEfficiency;
        }

        public Engine(string model, int power, string efficiency)
            : this(model, power)
        {
            this.displacement = defaultDisplacement;
            this.efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency)
            : this(model, power, displacement)
        {
            this.efficiency = efficiency;
        }

        public string Model { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{offset}{this.Model}:");
            sb.AppendLine($"{offset}{offset}Power: {this.power}");
            sb.AppendLine($"{offset}{offset}Displacement: {(this.displacement == -1 ? "n/a" : this.displacement.ToString())}");
            sb.AppendLine($"{offset}{offset}Efficiency: {this.efficiency}");

            return sb.ToString().TrimEnd();
        }
    }
}
