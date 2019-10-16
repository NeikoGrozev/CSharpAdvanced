using System;
using System.ComponentModel;

namespace CustomDataStructure
{
    public class CustomStack
    {
        private const int InitialCapacity = 4;

        private int[] items;

        private int count;

        public CustomStack()
        {
            this.items = new int[InitialCapacity];
            this.count = 0;
        }

        public int Count => this.count;

        public void Push(int item)
        {
            if(this.items.Length == this.count)
            {
                Resize();
            }
            this.items[this.count] = item;
            this.count++;
        }

        public int Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Custom Stack is empty!");
            }

            int lastItem = this.items[this.Count - 1];
            this.items[this.Count - 1] = default(int);
            this.count--;

            if (this.Count <= this.items.Length / 4)
            {
                Shrink();
            }

            return lastItem;
        }

        public int Peek()
        {
            int lastItem = this.items[this.Count - 1];

            return lastItem;
        }

        public void ForEach(Action<object> action)
        {
            for (int i = this.count - 1; i >= 0; i--)
            {
                action(this.items[i]);
            }
        }

        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }

        private void Shrink()
        {
            int[] copy = new int[this.items.Length / 2];

            for (int i = 0; i < copy.Length; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }

    }
}
