using System;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private double stats;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
            this.Stats = this.SumSkills();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public double Stats
        {
            get => this.stats;
            private set
            {
                this.stats = value;
            }
        }

        private int Endurance
        {
            get => this.endurance;
            set
            {
                if (this.ValidSkill("Endurance", value))
                {
                    this.endurance = value;
                }
            }
        }

        private int Sprint
        {
            get => this.sprint;
            set
            {
                if (this.ValidSkill("Sprint", value))
                {
                    this.sprint = value;
                }
            }
        }

        private int Dribble
        {
            get => this.dribble;
            set
            {
                if (this.ValidSkill("Dribble", value))
                {
                    this.dribble = value;
                }
            }
        }

        private int Passing
        {
            get => this.passing;
            set
            {
                if (this.ValidSkill("Passing", value))
                {
                    this.passing = value;
                }
            }
        }

        private int Shooting
        {
            get => this.shooting;
            set
            {
                if (this.ValidSkill("Shooting", value))
                {
                    this.shooting = value;
                }
            }
        }

        private bool ValidSkill(string skillName, int value)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{skillName} should be between 0 and 100.");
            }

            return true;
        }

        private int SumSkills()
        {
            int result = this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting;

            return (int)Math.Round(result / 5.0);
        }
    }
}
