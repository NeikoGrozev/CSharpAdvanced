namespace PartyReservationFilterModule
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

            List<string> filters = new List<string>();

            Func<string, string, bool> startWith = (name, str) =>
            {
                if (name.StartsWith(str))
                {
                    return true;
                }

                return false;
            };

            Func<string, string, bool> endsWith = (name, str) =>
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

            Func<string, string, bool> contains = (name, str) =>
            {
                if (name.Contains(str))
                {
                    return true;
                }

                return false;
            };

            while (true)
            {
                string[] token = Console.ReadLine()
                    .Split(";");

                string command = token[0];

                if (command == "Print")
                {
                    for (int i = 0; i < filters.Count; i+=2)
                    {
                        if (filters[i] == "Starts with")
                        {
                            for (int j = 0; j < names.Count; j++)
                            {
                                if (startWith(names[j], filters[i + 1]))
                                {
                                    names.RemoveAt(j);
                                    j--;
                                }
                            }
                        }
                        else if (filters[i] == "Ends with")
                        {
                            for (int j = 0; j < names.Count; j++)
                            {
                                if (endsWith(names[j], filters[i + 1]))
                                {
                                    names.RemoveAt(j);
                                    j--;
                                }
                            }
                        }
                        else if (filters[i] == "Length")
                        {
                            for (int j = 0; j < names.Count; j++)
                            {
                                if (length(names[j], int.Parse(filters[i + 1])))
                                {
                                    names.RemoveAt(j);
                                    j--;
                                }
                            }
                        }
                        else if (filters[i] == "Contains")
                        {
                            for (int j = 0; j < names.Count; j++)
                            {
                                if (contains(names[j], filters[i + 1]))
                                {
                                    names.RemoveAt(j);
                                    j--;
                                }
                            }
                        }
                    }

                    Console.WriteLine(string.Join(" ", names));

                    break;
                }

                string filterTypes = token[1];
                string str = token[2];

                if (command == "Add filter")
                {
                    filters.Add(filterTypes);
                    filters.Add(str);
                }
                else if (command == "Remove filter")
                {
                    for (int i = 0; i < filters.Count; i+=2)
                    {
                        if (filters[i] == filterTypes && filters[i + 1] == str)
                        {
                            filters.RemoveRange(i, 2);                            
                        }
                    }
                }
            }
        }
    }
}
