namespace Crossroads
{
    using System;
    using System.Collections.Generic;

    class CrossroadsProg
    {
        static void Main()
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>();
            string carName = string.Empty;
            char symbol = '\0';
            int counter = 0;
            bool isValid = true;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }
                else if (input == "green")
                {
                    int currentGreenLight = greenLight;

                    while (currentGreenLight > 0 && queue.Count > 0)
                    {
                        carName = queue.Dequeue();

                        if (currentGreenLight - carName.Length >= 0)
                        {
                            currentGreenLight -= carName.Length;
                            counter++;
                        }
                        else
                        {
                            currentGreenLight += freeWindow;

                            if (currentGreenLight - carName.Length >= 0)
                            {
                                counter++;
                                break;
                            }
                            else
                            {
                                int removeSymbolsCount = currentGreenLight;
                                symbol = carName[removeSymbolsCount];
                                isValid = false;
                                break;
                            }
                        }
                    }

                    if (!isValid)
                    {
                        break;
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }
            }

            if (isValid)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{counter} total cars passed the crossroads.");
            }
            else
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{carName} was hit at {symbol}.");
            }
        }
    }
}
