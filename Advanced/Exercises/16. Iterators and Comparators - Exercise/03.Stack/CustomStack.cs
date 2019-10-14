namespace Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> stack;

        private int index;

        public CustomStack()
        {
            this.stack = new List<T>();
            this.index = 0;
        }

        public void Push(params T[] elements)
        {
            this.stack.AddRange(elements.ToList());
            this.index = this.stack.Count - 1;
        }

        public void Pop()
        {
            if (this.stack.Count == 0)
            {
                Console.WriteLine("No elements");

                return;
            }

            this.stack.RemoveAt(index);
            index--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.stack.Count - 1; i >= 0; i--)
            {
                yield return this.stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();
    }
}
