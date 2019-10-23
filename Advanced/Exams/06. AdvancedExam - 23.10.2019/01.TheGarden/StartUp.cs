namespace TheGarden
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            char[][] garden = new char[n][];

            for (int row = 0; row < garden.Length; row++)
            {
                char[] input = Console.ReadLine()
                    .Split()
                    .Select(char.Parse)
                    .ToArray();

                garden[row] = new char[input.Length];

                for (int col = 0; col < garden[row].Length; col++)
                {
                    garden[row][col] = input[col];
                }

            }

            int carrots = 0;
            int potatoes = 0;
            int lettuce = 0;
            int harmedVegetables = 0;

            while (true)
            {
                string inputInfo = Console.ReadLine();

                if (inputInfo == "End of Harvest")
                {
                    break;
                }

                string[] input = inputInfo
                    .Split();

                string command = input[0];
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);

                if (command == "Harvest")
                {
                    if (row >= 0 && row < garden.Length && col >= 0 && col < garden[row].Length)
                    {
                        char ch = garden[row][col];

                        if (ch == 'C')
                        {
                            carrots++;
                        }
                        else if (ch == 'P')
                        {
                            potatoes++;
                        }
                        else if (ch == 'L')
                        {
                            lettuce++;
                        }

                        garden[row][col] = ' ';

                    }
                }
                else if (command == "Mole")
                {

                    if (row >= 0 && row < garden.Length && col >= 0 && col < garden[row].Length)
                    {
                        string destination = input[3];

                        if(destination == "up")
                        {
                            for (int r = row; r >= 0; r-=2)
                            {
                                if(garden[r][col] != ' ')
                                {
                                    harmedVegetables++;
                                    garden[r][col] = ' ';
                                }
                            }
                        }
                        else if(destination == "down")
                        {
                            for (int r = row; r < garden.Length; r+=2)
                            {
                                if(garden[r][col] != ' ')
                                {
                                    harmedVegetables++;
                                    garden[r][col] = ' ';
                                }
                            }
                        }
                        else if(destination == "left")
                        {
                            for (int c = col; c >= 0; c-=2)
                            {
                                if(garden[row][c] != ' ')
                                {
                                    harmedVegetables++;
                                    garden[row][c] = ' ';
                                }
                            }
                        }
                        else if(destination == "right")
                        {
                            for (int c = col; c < garden[row].Length; c+=2)
                            {
                                if(garden[row][c] != ' ')
                                {
                                    harmedVegetables++;
                                    garden[row][c] = ' ';
                                }
                            }
                        }
                    }

                }
            }

            for (int row = 0; row < garden.Length; row++)
            {
                Console.WriteLine(string.Join(" ", garden[row]));
            }

            Console.WriteLine($"Carrots: {carrots}");
            Console.WriteLine($"Potatoes: {potatoes}");
            Console.WriteLine($"Lettuce: {lettuce}");
            Console.WriteLine($"Harmed vegetables: {harmedVegetables}");
        }
    }
}
