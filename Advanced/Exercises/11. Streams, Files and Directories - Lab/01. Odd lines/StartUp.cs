namespace Oddlines
{
    using System;
    using System.IO;

    class StartUp
    {
        static void Main()
        {
            using (StreamReader reader = new StreamReader("../../../input.txt"))
            {
                int count = 0;

                using (StreamWriter writer = new StreamWriter("../../../output.txt"))

                    while (true)
                    {
                        string line = reader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        if (count % 2 == 1)
                        {
                            writer.WriteLine(line);
                        }

                        count++;
                    }
            }
        }
    }
}
