namespace ViceCity
{
    using Core;
    using Core.Contracts;

    public class StartUp
    {
        IEngine engine;
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}