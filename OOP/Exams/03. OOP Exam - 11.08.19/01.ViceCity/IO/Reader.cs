namespace ViceCity.IO
{
    using System;
    using Contracts;

    class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}