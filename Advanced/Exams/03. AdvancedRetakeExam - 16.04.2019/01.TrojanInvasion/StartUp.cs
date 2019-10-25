namespace TrojanInvasion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<int> spartanWarrior = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            spartanWarrior.Reverse();

            Stack<int> spartanDefense = new Stack<int>(spartanWarrior);
            Stack<int> trojanAttack = new Stack<int>();

            for (int i = 1; i <= n; i++)
            {
                int[] waves = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
               
                foreach (var item in waves)
                {
                    trojanAttack.Push(item);
                }

                if (i % 3 == 0)
                {
                    Stack<int> temp = new Stack<int>();
                    int newPlace = int.Parse(Console.ReadLine());

                    foreach (var item in spartanDefense)
                    {
                        temp.Push(item);
                    }

                    temp.Push(newPlace);
                    spartanDefense.Clear();

                    foreach (var item in temp)
                    {
                        spartanDefense.Push(item);
                    }
                }

                while (trojanAttack.Count > 0 && spartanDefense.Count > 0)
                {
                    int spartan = spartanDefense.Pop();
                    int trojan = trojanAttack.Pop();

                    if (spartan > trojan)
                    {
                        spartan -= trojan;
                        spartanDefense.Push(spartan);
                    }
                    else if (trojan > spartan)
                    {
                        trojan -= spartan;
                        trojanAttack.Push(trojan);
                    }
                }

                if (spartanDefense.Count == 0)
                {
                    break;
                }
            }

            if (spartanDefense.Count == 0)
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {string.Join(", ", trojanAttack)}");
            }
            else
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", spartanDefense)}");
            }
        }
    }
}
