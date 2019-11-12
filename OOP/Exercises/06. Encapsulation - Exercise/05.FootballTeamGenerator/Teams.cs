namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Teams
    {
        private List<Team> teams;

        public Teams()
        {
            this.teams = new List<Team>();
        }

        public List<Team> TeamsCollection
        {
            get => this.teams;
        }

        public void AddTeam(Team team)
        {
            if (!teams.Contains(team))
            {
                teams.Add(team);
            }
        }

        public void ValidTeam(string teamName)
        {
            if (!teams.Any(x => x.Name == teamName))
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }
        }
    }
}
