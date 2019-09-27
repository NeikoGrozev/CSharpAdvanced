namespace PredicateParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, string, bool> startWith = (name, str) =>
            {
                if (name.StartsWith(str))
                {
                    return true;
                }

                return false;
            };

            Func<string, string, bool> endtWith = (name, str) =>
            {
                if (name.EndsWith(str))
                {
                    return true;
                }

                return false;
            };

            Func<string, int, bool> length = (name, num) =>
            {
                if (name.Length == num)
                {
                    return true;
                }

                return false;
            };

            while (true)
            {
                string token = Console.ReadLine();

                if (token == "Party!")
                {
                    if (names.Count > 0)
                    {
                        Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
                    }
                    else
                    {
                        Console.WriteLine("Nobody is going to the party!");
                    }

                    break;
                }

                string[] command = token
                    .Split();

                string commandName = command[0];
                string criteria = command[1];
                string str = command[2];

                if (commandName == "Remove")
                {
                    for (int i = 0; i < names.Count; i++)
                    {
                        if (criteria == "StartsWith")
                        {
                            if (startWith(names[i], str))
                            {
                                names.RemoveAt(i);
                                i--;
                            }
                        }
                        else if (criteria == "EndsWith")
                        {
                            if (endtWith(names[i], str))
                            {
                                names.RemoveAt(i);
                                i--;
                            }
                        }
                        else if (criteria == "Length")
                        {
                            if (length(names[i], int.Parse(str)))
                            {
                                names.RemoveAt(i);
                                i--;

                            }
                        }
                    }
                }
                else if (commandName == "Double")
                {
                    for (int i = 0; i < names.Count; i++)
                    {
                        if (criteria == "StartsWith")
                        {
                            if (startWith(names[i], str))
                            {
                                names.Insert(i, names[i]);
                                i++;
                            }
                        }
                        else if (criteria == "EndsWith")
                        {
                            if (endtWith(names[i], str))
                            {
                                names.Insert(i, names[i]);
                                i++;
                            }
                        }
                        else if (criteria == "Length")
                        {
                            if (length(names[i], int.Parse(str)))
                            {
                                names.Insert(i, names[i]);
                                i++;
                            }
                        }
                    }
                }
            }
        }
    }
}
