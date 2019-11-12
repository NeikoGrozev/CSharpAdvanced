namespace Rabbits
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Cage
    {
        private List<Rabbit> data;

        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Rabbit>();
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int Count => this.data.Count;

        public void Add(Rabbit rabbit)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name)
        {
            return this.data.Remove(this.data.FirstOrDefault(x => x.Name == name));
        }


        public void RemoveSpecies(string species)
        {
            this.data.RemoveAll(x => x.Species == species);
        }

        public Rabbit SellRabbit(string name)
        {

            Rabbit result = this.data.FirstOrDefault(x => x.Name == name);
            result.Available = false;

            return result;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            List<Rabbit> rabbits = new List<Rabbit>();
            rabbits = this.data.Where(x => x.Species == species).ToList();

            for (int i = 0; i < rabbits.Count; i++)
            {
                rabbits[i].Available = false;
            }

            return rabbits.ToArray();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Rabbits available at {this.Name}:");

            foreach (var rab in this.data)
            {
                if (rab.Available == true)
                {
                    sb.AppendLine($"{rab}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}