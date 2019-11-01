namespace CarSalesman
{
    using System.Text;

    public class Car
    {
        private const string offset = "  ";
        private const int defaultWeight = -1;
        private const string defaultColor = "n/a";

        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car(string model, Engine engine)
        {
            this.model = model;
            this.engine = engine;
            this.weight = defaultWeight;
            this.color = defaultColor;
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine)
        {
            this.weight = weight;
            this.color = defaultColor;
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            this.weight = defaultWeight;
            this.color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine, weight)
        {          
            this.color = color;
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.model}:");
            sb.AppendLine(this.engine.ToString());
            sb.AppendLine($"{offset}Weight: {(this.weight == defaultWeight ? "n/a" : this.weight.ToString())}");
            sb.AppendLine($"{offset}Color: {this.color}");

            return sb.ToString().TrimEnd();
        }
    }
}
