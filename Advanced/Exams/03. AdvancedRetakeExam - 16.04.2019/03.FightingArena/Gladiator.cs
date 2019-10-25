namespace FightingArena
{
    using System.Text;

    public class Gladiator
    {
        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            this.Name = name;
            this.Stat = stat;
            this.Weapon = weapon;
        }

        public string Name { get; set; }

        public Stat Stat { get; set; }

        public Weapon Weapon { get; set; }

        public int GetStatPower()
        {
            int result = this.Stat.Strength
                + this.Stat.Flexibility
                + this.Stat.Agility
                + this.Stat.Skills
                + this.Stat.Intelligence;

            return result;
        }

        public int GetWeaponPower()
        {
            int result = this.Weapon.Size
                + this.Weapon.Solidity
                + this.Weapon.Sharpness;

            return result;
        }

        public int GetTotalPower()
        {
            int sum = GetStatPower() + GetWeaponPower();

            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"[{this.Name}] - [{GetTotalPower()}]");
            sb.AppendLine($"  Weapon Power: [{GetWeaponPower()}]");
            sb.AppendLine($"  Stat Power: [{GetStatPower()}]");

            return sb.ToString().TrimEnd();
        }
    }
}
