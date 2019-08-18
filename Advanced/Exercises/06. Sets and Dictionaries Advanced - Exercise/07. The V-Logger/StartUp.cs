namespace TheVLogger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class StartUp
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> dict =
                new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string joinPattern = $"(?<name>.*) joined The V-Logger";
            Regex joinRegex = new Regex(joinPattern);

            string followedPattern = $"(?<nameFollowers>.*) followed (?<vlogger>.*)";
            Regex followedRegex = new Regex(followedPattern);

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Statistics")
                {
                    break;
                }

                Match joinMatch = joinRegex.Match(command);
                Match followedMatch = followedRegex.Match(command);

                if (joinMatch.Success)
                {
                    string name = joinMatch.Groups["name"].Value;

                    if (!dict.ContainsKey(name))
                    {
                        dict.Add(name, new Dictionary<string, HashSet<string>>());
                        dict[name].Add("followers", new HashSet<string>());
                        dict[name].Add("followings", new HashSet<string>());
                    }
                }
                else if (followedMatch.Success)
                {
                    string nameFollows = followedMatch.Groups["nameFollowers"].Value;
                    string vlogger = followedMatch.Groups["vlogger"].Value;

                    if (dict.ContainsKey(vlogger) && nameFollows != vlogger
                        && dict.ContainsKey(nameFollows))
                    {
                        dict[vlogger]["followers"].Add(nameFollows);
                        dict[nameFollows]["followings"].Add(vlogger);
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {dict.Keys.Count} vloggers in its logs.");

            int count = 1;
            string mostFamousVlogger = string.Empty;

            foreach (var item in dict.OrderByDescending(x => x.Value["followers"].Count).ThenBy(x => x.Value["followings"].Count))
            {
                mostFamousVlogger = item.Key;

                Console.WriteLine($"{count++}. {mostFamousVlogger} : {item.Value["followers"].Count} followers, {item.Value["followings"].Count} following");

                foreach (var value in dict[mostFamousVlogger]["followers"].OrderBy(x => x))
                {
                    Console.WriteLine($"*  {value}");
                }

                break;
            }

            foreach (var item in dict.OrderByDescending(x => x.Value["followers"].Count).ThenBy(x => x.Value["followings"].Count))
            {
                if (item.Key != mostFamousVlogger)
                {
                    Console.WriteLine($"{count++}. {item.Key} : {item.Value["followers"].Count} followers, {item.Value["followings"].Count} following");
                }
            }
        }
    }
}
