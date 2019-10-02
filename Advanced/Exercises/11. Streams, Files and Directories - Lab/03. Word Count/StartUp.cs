namespace Word_Count
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;

    class StartUp
    {
        static void Main()
        {
            List<string> words = new List<string>();
            List<string> text = new List<string>();

            using (StreamReader readWords = new StreamReader(@"F:\C#2019\Advanced\Exercises\11. Streams, Files and Directories - Lab\03. Word Count\words.txt"))
            {
                while (true)
                {
                    string input = readWords.ReadLine();

                    if (input == null)
                    {
                        break;
                    }

                    string[] currentWords = input
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    foreach (var item in currentWords)
                    {
                        words.Add(item.ToLower());
                    }
                }
            }

            using (StreamReader readtext = new StreamReader(@"F:\C#2019\Advanced\Exercises\11. Streams, Files and Directories - Lab\03. Word Count\text.txt"))
            {
                while (true)
                {
                    string input = readtext.ReadLine();

                    if (input == null)
                    {
                        break;
                    }

                    string[] currentWords = input
                        .Split(new string[] { ".", ",", "-", " ", "...", "?", "!"}, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var item in currentWords)
                    {
                        text.Add(item.ToLower());
                    }
                }
            }

            Dictionary<string, int> dict = new Dictionary<string, int>();

            for (int i = 0; i < words.Count; i++)
            {
                for (int j = 0; j < text.Count; j++)
                {
                    if (words[i] == (text[j]))
                    {
                        if (!dict.ContainsKey(words[i]))
                        {
                            dict.Add(words[i], 0);
                        }

                        dict[words[i]]++;
                    }
                }
            }

            dict = dict
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, y => y.Value);

            using (StreamWriter witer = new StreamWriter(@"F:\C#2019\Advanced\Exercises\11. Streams, Files and Directories - Lab\03. Word Count\output.txt"))
            {
                foreach (var item in dict)
                {
                    witer.WriteLine($"{item.Key} - {item.Value}");
                }
            }
        }
    }
}
