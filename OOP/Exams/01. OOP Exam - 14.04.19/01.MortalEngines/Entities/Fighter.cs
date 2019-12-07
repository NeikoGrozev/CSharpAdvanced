namespace MortalEngines.Entities
{
    using Contracts;
    using System;
    using System.Text;

    public class Fighter : BaseMachine, IFighter
    {
        private const double healthPoints = 200d;
        private const double attackPointAtSetMode = 50d;
        private const double defenderPointAtSetMode = 25d;

        public Fighter(string name, double attackPoints, double defenderPoints)
            : base(name, attackPoints, defenderPoints, healthPoints)
        {
            this.AggressiveMode = true;
            this.SetPointToMode();
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            this.AggressiveMode = false;
            this.SetPointToMode();
        }

        private void SetPointToMode()
        {
            if (this.AggressiveMode == true)
            {
                this.AttackPoints += attackPointAtSetMode;
                this.DefensePoints -= defenderPointAtSetMode;
            }
            else
            {
                this.AttackPoints -= attackPointAtSetMode;
                this.DefensePoints += defenderPointAtSetMode;
            }
        }

        public override string ToString()
        {
            string aggressiveStatus = this.AggressiveMode ? "ON" : "OFF";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Aggressive: {aggressiveStatus}");

            return sb.ToString().TrimEnd();
        }        
    }
}