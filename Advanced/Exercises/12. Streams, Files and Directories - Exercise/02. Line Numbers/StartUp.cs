namespace LineNumbers
{
    using System;
    using System.IO;

    class StartUp
    {
        static void Main()
        {

            string[] stringLine = File.ReadAllLines("../../../text.txt");

            int count = 1;

            foreach (var line in stringLine)
            {
                int countLetter = 0;
                int countPunctuationMarks = 0;

                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] >= 'A' && line[i] <= 'Z' || line[i] >= 'a' && line[i] <= 'z')
                    {
                        countLetter++;
                    }
                    else if (line[i] != ' ')
                    {
                        countPunctuationMarks++;
                    }
                }

                File.AppendAllText("../../../output.txt", $"Line{count++}: {line}({countLetter})({countPunctuationMarks}){Environment.NewLine}");
            }

            //using (StreamWriter writer = new StreamWriter("../../../output.txt"))
            //{
            //    using (StreamReader reader = new StreamReader("../../../text.txt"))
            //    {
            //        while (true)
            //        {
            //            int countLetter = 0;
            //            int countPunctuationMarks = 0;

            //            string input = reader.ReadLine();

            //            if (input == null)
            //            {
            //                break;
            //            }

            //            for (int i = 0; i < input.Length; i++)
            //            {
            //                if (input[i] >= 'A' && input[i] <= 'Z' || input[i] >= 'a' && input[i] <= 'z')
            //                {
            //                    countLetter++;
            //                }
            //                else if (input[i] != ' ')
            //                {
            //                    countPunctuationMarks++;
            //                }
            //            }

            //            int count = 1;

            //            writer.WriteLine($"Line{count++}: {input}({countLetter})({countPunctuationMarks})");
            //        }
            //    }
            //}
        }
    }
}
