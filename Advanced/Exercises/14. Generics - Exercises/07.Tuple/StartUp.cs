namespace Tuple
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string[] firstInput = Console.ReadLine()
                .Split();

            string firstNname = firstInput[0];
            string secondName = firstInput[1];
            string address = firstInput[2];

            string[] secondInput = Console.ReadLine()
                .Split();
            string name = secondInput[0];
            int litersOfBeer = int.Parse(secondInput[1]);

            string[] thirdInput = Console.ReadLine()
                .Split();

            int integerNum = int.Parse(thirdInput[0]);
            double doubleNum = double.Parse(thirdInput[1]);

            var person = new Tuple<string, string>(firstNname + " " + secondName, address);

            var beer = new Tuple<string, int>(name, litersOfBeer);

            var number = new Tuple<int, double>(integerNum, doubleNum);

            Console.WriteLine(person.ToString());
            Console.WriteLine(beer.ToString());
            Console.WriteLine(number.ToString());
        }
    }
}
