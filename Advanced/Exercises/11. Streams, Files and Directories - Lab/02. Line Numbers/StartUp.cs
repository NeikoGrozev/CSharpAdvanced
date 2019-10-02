namespace LineNumbers
{
    using System;
    using System.IO;

    class StartUp
    {
        static void Main()
        {
            using (StreamReader reader = new StreamReader(@"F:\C#2019\Advanced\Exercises\11. Streams, Files and Directories - Lab\02. Line numbers\input.txt"))
            {
                int count = 1;

                using (StreamWriter writer = new StreamWriter(@"F:\C#2019\Advanced\Exercises\11. Streams, Files and Directories - Lab\02. Line numbers\output.txt"))

                    while (true)
                    {
                        string line = reader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        writer.WriteLine($"{count++}. " + line);

                    }
            }
        }
    }
}
