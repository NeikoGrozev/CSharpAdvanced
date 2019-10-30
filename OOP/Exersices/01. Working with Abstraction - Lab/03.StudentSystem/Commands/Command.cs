namespace StudentSystem.Commands
{
    public class Command
    {
        public Command(string name, string[] arguments)
        {
            this.Name = name;
            this.Arguments = arguments;
        }

        public string Name { get; set; }

        public string[] Arguments { get; set; }
    }
}
