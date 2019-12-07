namespace MortalEngines.IO.Contracts
{
    using System.Collections.Generic;

    public interface ICommand
    {
        string command { get; }

        IList<string> args { get; }
    }
}