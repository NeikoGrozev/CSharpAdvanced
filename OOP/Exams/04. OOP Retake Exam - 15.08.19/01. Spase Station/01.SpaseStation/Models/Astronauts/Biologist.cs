namespace SpaceStation.Models.Astronauts
{
    using System;

    public class Biologist : Astronaut
    {
        private const double oxygen = 70;
        private const double decreasesOxygen = 5;

        public Biologist(string name)
            : base(name, oxygen)
        {
        }

        public override void Breath()
        {
            this.Oxygen = Math.Max(0, this.Oxygen - decreasesOxygen);
        }
    }
}