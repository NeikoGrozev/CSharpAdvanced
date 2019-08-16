namespace SoftUniParty
{
    using System;
    using System.Collections.Generic;

    class SoftUniPartyProg
    {
        static void Main()
        {
            HashSet<string> vips = new HashSet<string>();
            HashSet<string> regulars = new HashSet<string>();

            while (true)
            {
                string guest = Console.ReadLine();

                if (guest == "PARTY")
                {
                    break;
                }
                else if (char.IsDigit(guest[0]))
                {
                    vips.Add(guest);
                }
                else
                {
                    regulars.Add(guest);
                }
            }

            while (true)
            {
                string guest = Console.ReadLine();

                if (guest == "END")
                {
                    break;
                }

                if (vips.Contains(guest))
                {
                    vips.Remove(guest);
                }
                else if (regulars.Contains(guest))
                {
                    regulars.Remove(guest);
                }
            }

            int numbersOfGuest = vips.Count + regulars.Count;
            Console.WriteLine(numbersOfGuest);

            foreach (var item in vips)
            {
                Console.WriteLine($"{item}");
            }

            foreach (var item in regulars)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}
