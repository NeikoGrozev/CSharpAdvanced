namespace CommandPattern.Core
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string postfix = "Command";
        public string Read(string args)
        {
            string[] inputCommnad = args
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string command = inputCommnad[0];

            string[] commandArguments = inputCommnad
                .Skip(1)
                .ToArray();

            string fullCommand = command + postfix;

            Assembly assembly = Assembly.GetCallingAssembly();

            Type[] allType = assembly
                .GetTypes();

            Type currentType = allType.FirstOrDefault(x => x.Name == fullCommand);

            Object instance = Activator.CreateInstance(currentType);

            ICommand commandRun = (ICommand)instance;

            string result = commandRun.Execute(commandArguments);

            return result;                
        }
    }
}