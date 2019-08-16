namespace ParkingLot
{
    using System;
    using System.Collections.Generic;

    class ParkingLotProg
    {
        static void Main()
        {

            HashSet<string> set = new HashSet<string>();

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                if (command == "END")
                {
                    break;
                }

                string numberOfCar = tokens[1];

                if (command == "IN")
                {
                    if (!set.Contains(numberOfCar))
                    {
                        set.Add(numberOfCar);
                    }
                }
                else if (command == "OUT")
                {
                    if (set.Contains(numberOfCar))
                    {
                        set.Remove(numberOfCar);
                    }
                }
            }

            if (set.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                Console.WriteLine($"{string.Join(Environment.NewLine, set)}");
            }
        }
    }
}
