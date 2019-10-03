namespace LineNumbers
{
    using System;
    using System.IO;

    class StartUp
    {
        static void Main()
        {
            using (StreamWriter writer = new StreamWriter(@"F:\C#2019\Advanced\Exercises\12. Streams, Files and Directories - Exercise\02. Line Numbers\output.txt"))
            {
                using (StreamReader reader = new StreamReader(@"F:\C#2019\Advanced\Exercises\12. Streams, Files and Directories - Exercise\02. Line Numbers\text.txt"))
                {
                    while (true)
                    {
                        int countLetter = 0;
                        int countPunctuationMarks = 0;

                        string input = reader.ReadLine();

                        if (input == null)
                        {
                            break;
                        }

                        for (int i = 0; i < input.Length; i++)
                        {
                            if (input[i] >= 'A' && input[i] <= 'Z' || input[i] >= 'a' && input[i] <= 'z')
                            {
                                countLetter++;
                            }
                            else if(input[i] != ' ')
                            {
                                countPunctuationMarks++;
                            }
                        }

                        int count = 1;

                        writer.WriteLine($"Line{count++}: {input}({countLetter})({countPunctuationMarks})");
                    }
                }
            }
        }
    }
}
