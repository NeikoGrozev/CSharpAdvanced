using System;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Engine
    {
        public void Run()
        {
            Teams teams = new Teams();

            while (true)
            {
                try
                {
                    string input = Console.ReadLine();

                    if (input == "END")
                    {
                        break;
                    }

                    string[] args = input
                        .Split(";");

                    string command = args[0];
                    string teamName = args[1];

                    if (command == "Team")
                    {
                        Team team = new Team(teamName);
                        teams.AddTeam(team);
                    }
                    else if (command == "Add")
                    {
                        teams.ValidTeam(teamName);

                        string playerName = args[2];
                        int endurance = int.Parse(args[3]);
                        int sprint = int.Parse(args[4]);
                        int dribble = int.Parse(args[5]);
                        int passing = int.Parse(args[6]);
                        int shooting = int.Parse(args[7]);

                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                        Team currentTeam = teams.TeamsCollection.FirstOrDefault(x => x.Name == teamName);

                        currentTeam.Add(player);
                    }
                    else if (command == "Remove")
                    {
                        teams.ValidTeam(teamName);

                        string playerName = args[2];

                        Team currentTeam = teams.TeamsCollection.FirstOrDefault(x => x.Name == teamName);

                        currentTeam.Remove(playerName);
                    }
                    else if (command == "Rating")
                    {
                        teams.ValidTeam(teamName);

                        Team currentTeam = teams.TeamsCollection.FirstOrDefault(x => x.Name == teamName);

                        Console.WriteLine(currentTeam);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}