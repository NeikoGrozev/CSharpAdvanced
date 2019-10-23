namespace Heroes
{
    using System.Collections.Generic;
    using System.Text;

    public class HeroRepository
    {
        private List<Hero> data;

        public HeroRepository()
        {
            this.data = new List<Hero>();
        }

        public int Count => this.data.Count;

        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }

        public void Remove(string name)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Name == name)
                {
                    this.data.RemoveAt(i);
                    break;
                }
            }
        }

        public Hero GetHeroWithHighestStrength()
        {
            Hero hero = null;
            int maxValue = int.MinValue;

            foreach (var item in data)
            {
                if(item.Item.Strength > maxValue)
                {
                    maxValue = item.Item.Strength;
                    hero = item;
                }
            }

            return hero;
        }

        public Hero GetHeroWithHighestAbility()
        {
            Hero hero = null;
            int maxValue = int.MinValue;

            foreach (var item in data)
            {
                if (item.Item.Ability > maxValue)
                {
                    maxValue = item.Item.Ability;
                    hero = item;
                }
            }

            return hero;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            Hero hero = null;
            int maxValue = int.MinValue;

            foreach (var item in data)
            {
                if (item.Item.Intelligence > maxValue)
                {
                    maxValue = item.Item.Intelligence;
                    hero = item;
                }
            }

            return hero;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
