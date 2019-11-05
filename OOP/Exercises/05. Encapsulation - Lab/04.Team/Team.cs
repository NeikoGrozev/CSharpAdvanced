namespace PersonsInfo
{
    using System.Collections.Generic;
    using System.Text;

    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.name = name;
            this.FirstTeam = new List<Person>();
            this.ReserveTeam = new List<Person>();
        }

        public List<Person> FirstTeam
        {
            get => this.firstTeam;
            private set
            {
                this.firstTeam = value;
            }
        }

        public List<Person> ReserveTeam
        {
            get => this.reserveTeam;
            private set
            {
                this.reserveTeam = value;
            }
        }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                this.FirstTeam.Add(person);
            }
            else
            {
                this.ReserveTeam.Add(person);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"First team has {this.FirstTeam.Count} players.");
            sb.AppendLine($"Reserve team has {this.ReserveTeam.Count} players.");

            return sb.ToString().TrimEnd();
        }
    }
}
