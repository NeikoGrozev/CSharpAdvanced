namespace StudentSystem
{
    using Commands;
    using Data;
    using Students;

    public class Engine
    {
        private CommandParser commandParser;
        private StudentSystem studentSystem;
        private IDataReader dataReader;
        private IDataWrite dataWrite;

        public Engine(CommandParser commandParser,
            StudentSystem studentSystem,
            IDataReader dataReader,
            IDataWrite dataWriter)
        {
            this.studentSystem = studentSystem;
            this.commandParser = commandParser;
            this.dataReader = dataReader;
            this.dataWrite = dataWriter;
        }

        public void Run()
        {

            while (true)
            {
                var data = dataReader.Read();
                var command = commandParser.Parse(data);

                if (command.Name == "Create")
                {
                    string name = command.Arguments[0];
                    int age = int.Parse(command.Arguments[1]);
                    double grade = double.Parse(command.Arguments[2]);

                    studentSystem.Add(name, age, grade);
                }
                else if (command.Name == "Show")
                {
                    string name = command.Arguments[0];
                    var student = studentSystem.Get(name);

                    this.dataWrite.Write(student);
                }
                else if (command.Name == "Exit")
                {
                    break;
                }
            }
        }
    }
}
