namespace FightingArena
{
    using System.Collections.Generic;
    using System.Linq;

    public class Arena
    {
        private List<Gladiator> gladiators;
        public Arena(string name)
        {
            this.Name = name;
            this.gladiators = new List<Gladiator>();
        }

        public string Name { get; private set; }

        public int Count => this.gladiators.Count;

        public void Add(Gladiator gladiator)
        {
            this.gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            Gladiator gladiator = this.gladiators.FirstOrDefault(x => x.Name == name);
            this.gladiators.Remove(gladiator);
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            Gladiator result = this.gladiators.OrderByDescending(x => x.GetStatPower()).First();

            return result;           
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            Gladiator result = this.gladiators.OrderByDescending(x => x.GetWeaponPower()).First();

            return result;           
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            Gladiator result = this.gladiators.OrderByDescending(x => x.GetTotalPower()).First();

            return result;            
        }

        public override string ToString()
        {
            return $"[{this.Name}] - [{this.Count}] gladiators are participating.";           
        }
    }
}
