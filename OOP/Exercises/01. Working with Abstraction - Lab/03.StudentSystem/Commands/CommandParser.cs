namespace StudentSystem.Commands
{
    using System.Linq;
    public class CommandParser
    {
        public Command Parse(string command)
        {
            var parts = command
                .Split();

            var name = parts[0];
            var arguments = parts.Skip(1).ToArray();

            var commnad = new Command(name, arguments);           

            return commnad;            
        }
    }
}
