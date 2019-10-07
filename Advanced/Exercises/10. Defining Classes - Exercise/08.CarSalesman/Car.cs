using System.Text;

namespace CarSalesman
{
    public class Car
    {
        public Car()
        {
            this.Model = string.Empty;
            this.Engine = null;
            this.Weigth = "n/a";
            this.Color = "n/a";
        }

        public Car(string model, Engine engine)
            : this()
        {
            this.Model = model;
            this.Engine = engine;
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine)
        {
            this.Weigth = weight.ToString();
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, string weigth, string color)
            : this(model, engine, color)
        {
            this.Weigth = weigth;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public string Weigth { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Model}:");
            sb.AppendLine($"  {Engine.Model}:");
            sb.AppendLine($"    Power: {Engine.Power}");
            sb.AppendLine($"    Displacement: {Engine.Displacement}");
            sb.AppendLine($"    Efficiency: {Engine.Efficiency}");
            sb.AppendLine($"  Weight: {Weigth}");
            sb.Append($"  Color: {Color}");

            return sb.ToString();
        }
    }
}
