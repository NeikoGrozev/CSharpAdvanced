namespace HealthyHeaven
{
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    public class Restaurant
    {
        private List<Salad> restaurant;

        public Restaurant(string name)
        {
            this.Name = name;
            this.restaurant = new List<Salad>();
        }

        public string Name { get; set; }

        public void Add(Salad salad)
        {
            restaurant.Add(salad);
        }

        public bool Buy(string name)
        {
            for (int i = 0; i < restaurant.Count; i++)
            {
                if (name == restaurant[i].Name)
                {
                    restaurant.RemoveAt(i);

                    return true;
                }
            }

            return false;
        }

        public Salad GetHealthiestSalad()
        {
            return restaurant.OrderBy(x => x.GetTotalCalories()).First();
        }

        public string GenerateMenu()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} have {this.restaurant.Count} salads:");

            foreach (var salad in restaurant)
            {
                sb.AppendLine($"{salad}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
