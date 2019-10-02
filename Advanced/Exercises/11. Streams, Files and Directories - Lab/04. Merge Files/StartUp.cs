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

            using (StreamReader readFirstFile = new StreamReader(@"F:\C#2019\Advanced\Exercises\11. Streams, Files and Directories - Lab\04. Merge Files\FileOne.txt"))
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

            using (StreamReader readSecondFile = new StreamReader(@"F:\C#2019\Advanced\Exercises\11. Streams, Files and Directories - Lab\04. Merge Files\FileTwo.txt"))
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

            using (StreamWriter witer = new StreamWriter(@"F:\C#2019\Advanced\Exercises\11. Streams, Files and Directories - Lab\04. Merge Files\output.txt"))
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
