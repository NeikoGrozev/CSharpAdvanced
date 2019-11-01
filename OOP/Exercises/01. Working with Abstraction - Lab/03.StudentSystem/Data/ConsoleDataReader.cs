using System;

namespace StudentSystem.Data
{
    public class ConsoleDataReader : IDataReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
