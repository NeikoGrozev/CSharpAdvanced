namespace CustomDoublyLinkedList
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            DoublyLinkedList doblyLinkedList = new DoublyLinkedList();

            doblyLinkedList.AddFirst(1);
            doblyLinkedList.AddFirst(2);
            doblyLinkedList.AddFirst(3);
            doblyLinkedList.AddFirst(4);

            doblyLinkedList.ForEach(x => Console.WriteLine(x));

            Console.WriteLine();

            foreach (var item in doblyLinkedList.ToArray())
            {
                Console.WriteLine(item);
            }
        }
    }
}
