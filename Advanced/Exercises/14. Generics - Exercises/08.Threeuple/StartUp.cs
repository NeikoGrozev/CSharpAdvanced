namespace Threeuple
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string[] firstInput = Console.ReadLine()
                .Split();

            string firstName = firstInput[0];
            string secondName = firstInput[1];
            string address = firstInput[2];
            string town = string.Empty;

            if (firstInput.Length > 4)
            {

                for (int i = 3; i < firstInput.Length; i++)
                {
                    town += firstInput[i] + " ";
                }
            }
            else
            {
                town = firstInput[3];
            }

            string[] secondInput = Console.ReadLine()
                .Split();

            string name = secondInput[0];
            int litersOfBeer = int.Parse(secondInput[1]);
            string drunkOrNot = secondInput[2] == "drunk"? "True" : "False";
            
            string[] thirdInput = Console.ReadLine()
                .Split();

            string namePerson = thirdInput[0];
            double accountBalance = double.Parse(thirdInput[1]);
            string bankName = thirdInput[2];

            var person = new Tuple<string, string, string>(firstName + " " + secondName, address, town);

            var beer = new Tuple<string, int, string>(name, litersOfBeer, drunkOrNot);

            var account = new Tuple<string, double, string>(namePerson, accountBalance, bankName);

            Console.WriteLine(person.ToString());
            Console.WriteLine(beer.ToString());
            Console.WriteLine(account.ToString());
        }
    }
}
