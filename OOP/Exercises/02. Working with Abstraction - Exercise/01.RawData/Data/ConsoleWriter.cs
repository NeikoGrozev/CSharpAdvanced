namespace RawData.Data
{
    using System;

    class ConsoleWriter : IDataWriter
    {
        public void Write(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}
