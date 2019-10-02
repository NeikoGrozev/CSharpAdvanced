namespace SliceAFile
{
    using System;
    using System.IO;

    class StartUp
    {
        static void Main()
        {
            long totalSize = new FileInfo(@"F:\C#2019\Advanced\Exercises\11. Streams, Files and Directories - Lab\05. Slice a File\sliceMe.txt").Length;

            int sizePerFile = (int)Math.Ceiling(totalSize / 4.0);

            using (FileStream inputFile = new FileStream(@"F:\C#2019\Advanced\Exercises\11. Streams, Files and Directories - Lab\05. Slice a File\sliceMe.txt", FileMode.Open))
            {
                for (int i = 0; i < 4; i++)
                {
                    byte[] buffer = new byte[sizePerFile];
                    var readBytes = inputFile.Read(buffer, 0, sizePerFile);

                    using (FileStream write = new FileStream($@"F:\C#2019\Advanced\Exercises\11. Streams, Files and Directories - Lab\05. Slice a File\Part-{i}.txt", FileMode.OpenOrCreate))
                    {
                        write.Write(buffer, 0, sizePerFile);
                    }
                }
            }
        }
    }
}
