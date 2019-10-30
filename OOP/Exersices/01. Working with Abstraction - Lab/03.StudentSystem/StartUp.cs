namespace StudentSystem
{
    using Commands;
    using Students;
    using StudentSystem.Data;

    public class StartUp
    {
        public static void Main()
        {
            var commandParser = new CommandParser();
            var studentSystem = new StudentSystem();
            var datareader = new ConsoleDataReader();
            var dataWriter = new ConsoleDataWriter();

            var engine = new Engine(commandParser, studentSystem, datareader, dataWriter);

            engine.Run();
        }
    }
}
