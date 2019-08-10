namespace TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TruckTourProg
    {
        static void Main()
        {
            int numbersOfPomp = int.Parse(Console.ReadLine());

            Queue<int[]> petrolPomps = new Queue<int[]>();            

            for (int i = 0; i < numbersOfPomp; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();
                petrolPomps.Enqueue(input);                
            }

            for (int i = 0; i < numbersOfPomp; i++)
            {
                int sumPetrol = 0;                

                foreach (var pomp in petrolPomps)
                {                
                    int petrol = pomp[0];
                    int distance = pomp[1];
                    sumPetrol += petrol - distance;

                    if (sumPetrol < 0)
                    {
                        petrolPomps.Enqueue(petrolPomps.Dequeue());
                        break;
                    }                    
                }

                if (sumPetrol >= 0)
                {
                    Console.WriteLine(i);
                    break;
                }               
            }
        }
    }
}
