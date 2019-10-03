namespace CopyBinaryFile
{
    using System;
    using System.IO;

    class StartUp
    {
        static void Main()
        {
            using (FileStream reader = new FileStream("../../../copyMe.png", FileMode.Open))
            {
                using (FileStream writer = new FileStream("../../../copyMe - copy.png", FileMode.Create))
                {
                    while (true)
                    {
                        byte[] byteArray = new byte[4096];

                        int size = reader.Read(byteArray, 0, byteArray.Length);

                        if (size == 0)
                        {
                            break;
                        }

                        writer.Write(byteArray, 0, size);
                    }
                }
            }
        }
    }
}
