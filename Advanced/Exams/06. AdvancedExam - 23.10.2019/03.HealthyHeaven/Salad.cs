namespace HealthyHeaven
{
    using System.Collections.Generic;
    using System.Text;

    public class Salad
    {
        private List<Vegetable> salad;

        public Salad(string name)
        {
            this.Name = name;
            this.salad = new List<Vegetable>();
        }

        public string Name { get; set; }

        public int GetTotalCalories()
        {
            int sum = 0;

            foreach (var item in salad)
            {
                sum += item.Calories;
            }

            return sum;
        }

        public int GetProductCount()
        {
            int count = salad.Count;

            return count;
        }

        public void Add(Vegetable product)
        {
            salad.Add(product);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"* Salad {this.Name} is {GetTotalCalories()} calories and have {GetProductCount()} products:");

            foreach (var vegetable in salad)
            {
                sb.AppendLine($"{vegetable}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
