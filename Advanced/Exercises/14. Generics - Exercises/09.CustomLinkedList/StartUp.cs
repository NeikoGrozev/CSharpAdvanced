namespace CustomLinkedList
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            var list = new CustomList<int>();

            for (int i = 0; i <= 10; i++)
            {
                list.Add(i);
            }

            //Console.WriteLine(list.ToString());


            list.RemoveAt(10);

            //Console.WriteLine(list.ToString());

            //list.Insert(9, 10);

            //Console.WriteLine(list.ToString());

            Console.WriteLine(list.Contains(7));

            //list.Swap(0, 9);

            //Console.WriteLine(list.ToString());


            list.Revers();

            Console.WriteLine(list.ToString());

        }
    }
}
