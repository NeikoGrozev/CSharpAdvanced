namespace PlayersAndMonsters.Core
{
    using Contracts;
    using System;

    public class CommandInterpreter : ICommandInterpeter
    {
        private readonly IManagerController managerController;

        public CommandInterpreter(IManagerController managerController)
        {
            this.managerController = managerController;
        }

        public string Read(string[] args)
        {
            string typeCommand = args[0];

            string output = string.Empty;

            switch (typeCommand)
            {
                case "AddPlayer":
                    output = this.managerController.AddPlayer(args[1], args[2]);
                    break;
                case "AddCard":
                    output = this.managerController.AddCard(args[1], args[2]);
                    break;
                case "AddPlayerCard":
                    output = this.managerController.AddPlayerCard(args[1], args[2]);
                    break;
                case "Fight":
                    output = this.managerController.Fight(args[1], args[2]);
                    break;
                case "Report":
                    output = this.managerController.Report();
                    break;
                default:
                    throw new ArgumentException("Command is not existing!");
            }

            return output;
        }
    }
}