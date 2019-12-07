namespace MortalEngines.Entities
{
    using Contracts;
    using System.Text;

    public class Tank : BaseMachine, ITank
    {
        private const double healthPoints = 100d;
        private const double attackPointAtSetMode = 40d;
        private const double defenderPointAtSetMode = 30d;

        public Tank(string name, double attackPoints, double defenderPoints)
            : base(name, attackPoints, defenderPoints, healthPoints)
        {
            this.DefenseMode = true;
            SetPointToMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            this.DefenseMode = false;
            SetPointToMode();
        }

        private void SetPointToMode()
        {
            if (this.DefenseMode == true)
            {
                this.AttackPoints -= attackPointAtSetMode;
                this.DefensePoints += defenderPointAtSetMode;
            }
            else
            {
                this.AttackPoints += attackPointAtSetMode;
                this.DefensePoints -= defenderPointAtSetMode;
            }
        }

        public override string ToString()
        {
            string defenseStatus = this.DefenseMode ? "ON" : "OFF";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Defense: {defenseStatus}");

            return sb.ToString().TrimEnd();
        }
    }
}