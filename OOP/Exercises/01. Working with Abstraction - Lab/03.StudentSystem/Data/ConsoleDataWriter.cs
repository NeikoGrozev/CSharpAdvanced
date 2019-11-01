namespace StudentSystem.Data
{
    using System;

    class ConsoleDataWriter : IDataWrite
    {
        public void Write(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}
