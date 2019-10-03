namespace MergeFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class StartUp
    {
        static void Main()
        {
            List<string> firstList = new List<string>();
            List<string> secondList = new List<string>();

            using (StreamReader readFirstFile = new StreamReader("../../../FileOne.txt"))
            {
                while (true)
                {
                    string input = readFirstFile.ReadLine();

                    if (input == null)
                    {
                        break;
                    }

                    firstList.Add(input);
                }
            }

            using (StreamReader readSecondFile = new StreamReader("../../../FileTwo.txt"))
            {
                while (true)
                {
                    string input = readSecondFile.ReadLine();

                    if (input == null)
                    {
                        break;
                    }

                    secondList.Add(input);
                }
            }

            using (StreamWriter witer = new StreamWriter("../../../output.txt"))
            {
                for (int i = 0; i < firstList.Count; i++)
                {
                    witer.WriteLine(firstList[i]);
                    witer.WriteLine(secondList[i]);
                }
            }
        }
    }
}
