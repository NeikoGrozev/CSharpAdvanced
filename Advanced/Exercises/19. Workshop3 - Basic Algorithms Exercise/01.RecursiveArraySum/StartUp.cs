namespace RecursiveArraySum
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(Sum(array, array.Length));
        }

        public static int Sum(int[] array, int index)
        {
            if (index == 1)
            {
                return array[0];
            }

            return (array[index - 1] + Sum(array, index - 1));         
        }
    }
}
