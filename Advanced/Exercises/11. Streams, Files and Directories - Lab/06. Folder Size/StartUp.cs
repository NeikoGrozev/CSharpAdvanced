
namespace FolderSize
{
    using System;
    using System.IO;

    class StartUp
    {
        static void Main()
        {
            var files = Directory.GetFiles("../../../TestFolder");
            double totalLength = 0;

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                totalLength += fileInfo.Length;
            }

            totalLength /= Math.Pow(1024, 2);

            using (StreamWriter write = new StreamWriter("../../../output.txt"))
            {
                write.WriteLine(totalLength);
            }
        }
    }
}
