namespace AquariumAdventure
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Aquarium
    {
        private List<Fish> fishInPool;

        public Aquarium(string name, int capacity, int size)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Size = size;
            this.fishInPool = new List<Fish>();
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int Size { get; private set; }

        public void Add(Fish fish)
        {
            if(fishInPool.Count < this.Capacity)
            {
                if(!fishInPool.Contains(fish))
                {
                    fishInPool.Add(fish);
                }
            }
        }

        public bool Remove(string name)
        {
            for (int i = 0; i < fishInPool.Count; i++)
            {
                if(fishInPool[i].Name == name)
                {
                    fishInPool.RemoveAt(i);

                    return true;
                }
            }

            return false;
        }

        public Fish FindFish(string name)
        {
            Fish result = null;

            for (int i = 0; i < fishInPool.Count; i++)
            {
                if(fishInPool[i].Name == name)
                {
                    result = fishInPool[i];
                }
            }

            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Aquarium: {this.Name} ^ Size: {this.Size}");

            foreach (var fish in fishInPool)
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
