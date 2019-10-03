namespace SliceAFile
{
    using System;
    using System.IO;

    class StartUp
    {
        static void Main()
        {
            long totalSize = new FileInfo("../../../sliceMe.txt").Length;

            int sizePerFile = (int)Math.Ceiling(totalSize / 4.0);

            using (FileStream inputFile = new FileStream("../../../sliceMe.txt", FileMode.Open))
            {
                for (int i = 0; i < 4; i++)
                {
                    byte[] buffer = new byte[sizePerFile];
                    var readBytes = inputFile.Read(buffer, 0, sizePerFile);

                    using (FileStream write = new FileStream($"../../../Part-{i}.txt", FileMode.OpenOrCreate))
                    {
                        write.Write(buffer, 0, sizePerFile);
                    }
                }
            }
        }
    }
}
