namespace CustomRandomList
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            RandomList randomList = new RandomList();

            for (int i = 1; i <= 10; i++)
            {
                randomList.Add($"{i}");
            }

            Console.WriteLine(string.Join(" ", randomList));

            Console.WriteLine(randomList.RandomString());

            Console.WriteLine(string.Join(" ", randomList));
        }
    }
}
