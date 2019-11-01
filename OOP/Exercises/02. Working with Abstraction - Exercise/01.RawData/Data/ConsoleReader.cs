namespace RawData.Data
{
    using System;

    public class ConsoleReader : IDataReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
