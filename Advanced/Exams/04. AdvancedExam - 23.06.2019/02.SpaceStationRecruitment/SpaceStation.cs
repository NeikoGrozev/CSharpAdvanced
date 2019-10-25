namespace SpaceStationRecruitment
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SpaceStation
    {
        private List<Astronaut> data;

        public SpaceStation(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Astronaut>();
        }

        public string Name { get; set; }

        public int Capacity { get; private set; }

        public int Count => this.data.Count;

        public void Add(Astronaut astronaut)
        {
            if (data.Count < this.Capacity)
            {
                data.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Name == name)
                {
                    data.RemoveAt(i);

                    return true;
                }
            }

            return false;
        }

        public Astronaut GetOldestAstronaut()
        {
            Astronaut result = data.OrderByDescending(x => x.Age).FirstOrDefault();

            return result;
        }

        public Astronaut GetAstronaut(string name)
        {
            Astronaut result = data.Where(x => x.Name == name).FirstOrDefault();

            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (var astronaut in data)
            {
                sb.AppendLine($"{astronaut}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
