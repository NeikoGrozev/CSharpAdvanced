namespace MortalEngines.IO.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Reader : IReader
    {
        public IList<ICommand> ReadCommands()
        {
            var input = Console.ReadLine()
                .Split();

            var commandString = input[0];
            var args = input
                .Skip(1)
                .ToList();
            
            return new List<ICommand>();
        }
    }
}