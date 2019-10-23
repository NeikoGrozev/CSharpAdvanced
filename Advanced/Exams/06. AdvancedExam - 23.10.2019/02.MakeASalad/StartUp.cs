namespace MakeASalad
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            string[] inputVegetables = Console.ReadLine()
                .Split();
            int[] inputCalories = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<string> vegetables = new Queue<string>(inputVegetables);
            Stack<int> calories = new Stack<int>(inputCalories);

            Dictionary<string, int> tableCalories = new Dictionary<string, int>();

            tableCalories["tomato"] = 80;
            tableCalories["carrot"] = 136;
            tableCalories["lettuce"] = 109;
            tableCalories["potato"] = 215;

            Queue<int> salads = new Queue<int>(calories);

            while (true)
            {
                if (vegetables.Count == 0 || calories.Count == 0)
                {
                    break;
                }

                int currentCalories = calories.Pop();
                string currentVegetable = vegetables.Dequeue();

                int currentVegetableCalories = tableCalories.FirstOrDefault(x => x.Key == currentVegetable).Value;

                if (currentCalories > currentVegetableCalories)
                {
                    currentCalories -= currentVegetableCalories;

                    if (vegetables.Count != 0)
                    {
                        calories.Push(currentCalories);
                    }
                }
            }

            int diff = salads.Count - calories.Count;

            for (int i = 0; i < diff; i++)
            {
                Console.Write($"{salads.Dequeue()} ");
            }

            Console.WriteLine();

            if (calories.Count != 0)
            {
                Console.WriteLine(string.Join(" ", calories));
            }
            else
            {
                Console.WriteLine(string.Join(" ", vegetables));
            }
        }
    }
}
