namespace SimpleTextEditor
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class SimpleTextEditorProg
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            StringBuilder builder = new StringBuilder();
            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ");

                string command = input[0];

                if (command == "1")
                {
                    string word = input[1];
                    stack.Push(builder.ToString());
                    builder.Append(word);
                }
                else if (command == "2")
                {
                    int count = int.Parse(input[1]);

                    if (count > builder.Length)
                    {
                        count = builder.Length;
                    }

                    stack.Push(builder.ToString());
                    builder.Remove(builder.Length - count, count);
                }
                else if (command == "3")
                {
                    int index = int.Parse(input[1]);

                    if (index > builder.Length)
                    {
                        index = builder.Length;
                    }

                    Console.WriteLine(builder[index - 1]);
                }
                else if (command == "4")
                {
                    builder.Remove(0, builder.Length);
                    builder.Append(stack.Pop());
                }
            }
        }
    }
}
