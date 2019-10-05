namespace ZipAndExtract
{
    using System;
    using System.IO.Compression;

    class StartUp
    {
        static void Main()
        {
            ZipFile.CreateFromDirectory("../../../Test folder", "../../../file.zip");
            ZipFile.ExtractToDirectory("../../../file.zip", "../../../");
        }
    }
}
