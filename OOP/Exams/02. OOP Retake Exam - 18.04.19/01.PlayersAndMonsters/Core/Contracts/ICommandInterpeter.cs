namespace PlayersAndMonsters.Core.Contracts
{
    public interface ICommandInterpeter
    {
        string Read(string[] args);
    }
}