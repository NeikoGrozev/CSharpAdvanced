namespace Oddlines
{
    using System;
    using System.IO;

    class StartUp
    {
        static void Main()
        {
            using (StreamReader reader = new StreamReader(@"F:\C#2019\Advanced\Exercises\11. Streams, Files and Directories - Lab\01. Odd lines\input.txt"))
            {
                int count = 0;

                using (StreamWriter writer = new StreamWriter(@"F:\C#2019\Advanced\Exercises\11. Streams, Files and Directories - Lab\01. Odd lines\output.txt"))

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
