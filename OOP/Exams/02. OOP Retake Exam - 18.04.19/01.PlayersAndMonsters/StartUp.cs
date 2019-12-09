namespace PlayersAndMonsters
{
    using Core;
    using Core.Contracts;
    using Core.Factories;
    using Core.Factories.Contracts;
    using IO;
    using IO.Contracts;
    using Models.BattleFields;
    using Models.BattleFields.Contracts;
    using Repositories;
    using Repositories.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();

            IPlayerFactory playerFactory = new PlayerFactory();
            IPlayerRepository playerRepository = new PlayerRepository();
            ICardFactory cardFactory = new CardFactory();
            ICardRepository cardRepository = new CardRepository();
            IBattleField battleField = new BattleField();

            IManagerController managerController = new ManagerController(
                playerFactory,
                playerRepository,
                cardFactory,
                cardRepository,
                battleField);

            CommandInterpreter commandInterpreter = new CommandInterpreter(managerController);
            Engine engine = new Engine(commandInterpreter, reader, writer);
            engine.Run();
        }
    }
}