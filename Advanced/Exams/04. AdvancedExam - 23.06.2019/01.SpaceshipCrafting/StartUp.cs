namespace SpaceshipCrafting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            const int glass = 25;
            const int aluminium = 50;
            const int lithium = 75;
            const int carbonFiber = 100;

            int[] chemicalLiquids = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] physicalItems = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> liquids = new Queue<int>(chemicalLiquids);
            Stack<int> items = new Stack<int>(physicalItems);

            Dictionary<string, int> table = new Dictionary<string, int>();
            table["Glass"] = 0;
            table["Aluminium"] = 0;
            table["Lithium"] = 0;
            table["Carbon fiber"] = 0;

            while (liquids.Count > 0 && items.Count > 0)
            {
                int currentLiquid = liquids.Dequeue();
                int currentItem = items.Pop();

                int elementSum = currentLiquid + currentItem;

                if (elementSum == glass)
                {
                    table["Glass"]++;
                }
                else if (elementSum == aluminium)
                {
                    table["Aluminium"]++;
                }
                else if (elementSum == lithium)
                {
                    table["Lithium"]++;
                }
                else if(elementSum == carbonFiber)
                {
                    table["Carbon fiber"]++;
                }
                else
                {
                    items.Push(currentItem + 3);
                }
            }

            bool isTrue = table.Any(x => x.Value == 0);

            if(!isTrue)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if(liquids.Count != 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if(items.Count != 0)
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", items)}");
            }
            else
            {
                Console.WriteLine("Physical items left: none");
            }

            foreach (var item in table.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
