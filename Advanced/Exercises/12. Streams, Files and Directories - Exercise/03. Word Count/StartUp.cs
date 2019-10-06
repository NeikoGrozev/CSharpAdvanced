namespace Word_Count
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;


    class StartUp
    {
        static void Main()
        {
            string[] words = File.ReadAllLines("../../../words.txt");

            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!dict.ContainsKey(word))
                {
                    dict.Add(word, 0);
                }
            }

            string[] inputText = File.ReadAllLines("../../../text.txt");

            foreach (var text in inputText)
            {
                string[] splittedText = text
                    .Split(new string[] { ".", ",", "-", " ", "...", "?", "!", ";", ":" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in splittedText)
                {
                    if (dict.ContainsKey(item.ToLower()))
                    {
                        dict[item.ToLower()]++;
                    }
                }
            }

            foreach (var item in dict)
            {
                File.AppendAllText("../../../actualResult.txt", $"{item.Key} - {item.Value}{Environment.NewLine}");
            }

            dict = dict
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var item in dict)
            {
                File.AppendAllText("../../../expectedResult.txt", $"{item.Key} - {item.Value}{Environment.NewLine}");
            }
        }
    }
}
