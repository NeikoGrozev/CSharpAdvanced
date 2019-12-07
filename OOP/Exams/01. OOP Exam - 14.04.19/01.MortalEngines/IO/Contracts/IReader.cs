namespace MortalEngines.IO.Contracts
{
    using System.Collections.Generic;

    public interface IReader
    {
        IList<ICommand> ReadCommands();
    }
}