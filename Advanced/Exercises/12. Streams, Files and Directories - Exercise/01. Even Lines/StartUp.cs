namespace EvenLines
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class StartUp
    {
        static void Main()
        {
            int count = 0;

            using (StreamWriter writer = new StreamWriter("../../../output.txt"))
            {
                using (StreamReader reader = new StreamReader("../../../text.txt"))
                {
                    while (true)
                    {
                        string inputStr = reader.ReadLine();

                        if (inputStr == null)
                        {
                            break;
                        }

                        string[] input = inputStr
                            .Split(" ");

                        List<string> currentStr = new List<string>();
                        List<string> symbols = new List<string> { "-", ",", ".", "!", "?" };

                        if (count % 2 == 0)
                        {
                            for (int i = input.Length - 1; i >= 0; i--)
                            {
                                string temp = string.Empty;

                                for (int j = 0; j < input[i].Length; j++)
                                {
                                    if (symbols.Contains(input[i][j].ToString()))
                                    {
                                        temp += "@";
                                    }
                                    else
                                    {
                                        temp += input[i][j];
                                    }
                                }

                                currentStr.Add(temp);
                            }

                            writer.WriteLine(string.Join(" ", currentStr));
                        }

                        count++;
                    }
                }
            }
        }
    }
}
