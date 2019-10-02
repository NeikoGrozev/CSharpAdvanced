
namespace FolderSize
{
    using System;
    using System.IO;

    class StartUp
    {
        static void Main()
        {
            var files = Directory.GetFiles(@"F:\C#2019\Advanced\Exercises\11. Streams, Files and Directories - Lab\06. Folder Size\TestFolder");
            double totalLength = 0;

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                totalLength += fileInfo.Length;
            }

            totalLength /= Math.Pow(1024, 2);

            using (StreamWriter write = new StreamWriter(@"F:\C#2019\Advanced\Exercises\11. Streams, Files and Directories - Lab\06. Folder Size\output.txt"))
            {
                write.WriteLine(totalLength);
            }
        }
    }
}
