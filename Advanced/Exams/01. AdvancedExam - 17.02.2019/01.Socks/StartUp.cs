namespace Socks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            int[] inputLeftSocks = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] inputRightSocks = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> inputStack = new Stack<int>(inputLeftSocks);
            Queue<int> inputQueue = new Queue<int>(inputRightSocks);

            List<int> pairSocks = new List<int>();

            while (true)
            {
                if(inputStack.Count == 0 || inputQueue.Count == 0)
                {
                    Console.WriteLine(pairSocks.Max());
                    Console.WriteLine(string.Join(" ", pairSocks));

                    break;
                }

                int currentStack = inputStack.Peek();
                int currentQueue = inputQueue.Peek();

                if(currentStack > currentQueue)
                {
                    int sum = inputStack.Pop() + inputQueue.Dequeue();
                    pairSocks.Add(sum);
                }
                else if(currentStack < currentQueue)
                {
                    inputStack.Pop();
                }
                else if(currentStack == currentQueue)
                {
                    int temp = inputStack.Pop() + 1;
                    inputStack.Push(temp);

                    inputQueue.Dequeue();
                }
            }
        }
    }
}
