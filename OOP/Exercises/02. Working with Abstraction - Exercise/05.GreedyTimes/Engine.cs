namespace GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private Dictionary<string, Dictionary<string, long>> bag;
        private long gold;
        private long gem;
        private long cash;
        private string name;
        private long numbersOfItem;

        public void Run()
        {
            this.bag = new Dictionary<string, Dictionary<string, long>>();

            long bagCapacity = long.Parse(Console.ReadLine());
            string[] items = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);


            for (int i = 0; i < items.Length; i += 2)
            {
                name = items[i];
                numbersOfItem = long.Parse(items[i + 1]);

                string currentName = string.Empty;

                if (name.Length == 3)
                {
                    currentName = "Cash";
                }
                else if (name.ToLower().EndsWith("gem"))
                {
                    currentName = "Gem";
                }
                else if (name.ToLower() == "gold")
                {
                    currentName = "Gold";
                }

                if (currentName == "")
                {
                    continue;
                }
                else if (bagCapacity < bag.Values.Select(x => x.Values.Sum()).Sum() + numbersOfItem)
                {
                    continue;
                }

                switch (currentName)
                {
                    case "Gem":
                        if (!bag.ContainsKey(currentName))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (numbersOfItem > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[currentName].Values.Sum() + numbersOfItem > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!bag.ContainsKey(currentName))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (numbersOfItem > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[currentName].Values.Sum() + numbersOfItem > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;

                }

                AddItemToBag(name, currentName, numbersOfItem);
            }

            Print();
        }

        private void AddItemToBag(string name, string currentName, long numbersOfItem)
        {
            if (!bag.ContainsKey(currentName))
            {
                bag[currentName] = new Dictionary<string, long>();
            }

            if (!bag[currentName].ContainsKey(name))
            {
                bag[currentName][name] = 0;
            }

            bag[currentName][name] += numbersOfItem;
            if (currentName == "Gold")
            {
                gold += numbersOfItem;
            }
            else if (currentName == "Gem")
            {
                gem += numbersOfItem;
            }
            else if (currentName == "Cash")
            {
                cash += numbersOfItem;
            }
        }

        public void Print()
        {
            foreach (var x in bag)
            {
                Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
                foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }
    }
}
