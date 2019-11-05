namespace PersonsInfo
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Team team = new Team("SoftUni");

            var lines = int.Parse(Console.ReadLine());
           
            for (int i = 0; i < lines; i++)
            {
                try
                {
                    var cmdArgs = Console.ReadLine().Split();
                    var person = new Person(cmdArgs[0],
                                            cmdArgs[1],
                                            int.Parse(cmdArgs[2]),
                                            decimal.Parse(cmdArgs[3]));

                    team.AddPlayer(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(team);
        }
    }
}
