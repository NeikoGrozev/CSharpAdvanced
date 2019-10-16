namespace CustomLinkedList
{
    using System;

    public class CustomList<T>
    {
        private const int InitialCapacity = 2;

        private T[] items;

        public CustomList()
        {
            this.items = new T[InitialCapacity];
            this.Count = 0;
        }

        public int Count { get; set; }

        public T this[int index]
        {
            get
            {
                return this.items[index];
            }
            set
            {
                this.items[index] = value;
            }
        }
        public void Add(T item)
        {
            if (this.Count == this.items.Length)
            {
                Resize();
            }

            this.items[this.Count] = item;
            this.Count++;
        }

        public void RemoveAt(int index)
        {
            if (CorrectIndex(index))
            {
                Shift(index);
                this.items[Count - 1] = default(T);
                this.Count--;
            }

            if (this.Count <= this.items.Length / 4)
            {
                Shrink();
            }
        }

        public void Insert(int index, T item)
        {
            if (CorrectIndex(index))
            {
                ShiftToRigth(index);
                this.items[index] = item;
                this.Count++;
            }
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (item.Equals(this.items[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (CorrectIndex(firstIndex) && CorrectIndex(secondIndex))
            {
                T item = this.items[firstIndex];
                this.items[firstIndex] = this.items[secondIndex];
                this.items[secondIndex] = item;
            }
        }

        public void Revers()
        {
            for (int i = 0; i < this.Count / 2; i++)
            {
                Swap(i, this.Count - i - 1);
            }
        }

        private void Resize()
        {
            T[] copy = new T[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }

        private void Shrink()
        {
            T[] copy = new T[this.items.Length / 2];

            for (int i = 0; i < copy.Length; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.Count; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }

        private bool CorrectIndex(int index)
        {
            if (index >= 0 && index < this.Count)
            {
                return true;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Index out ot range array!");
            }
        }

        private void ShiftToRigth(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }

        public override string ToString()
        {
            string result = string.Empty;

            for (int i = 0; i < this.Count; i++)
            {
                result += $"{this.items[i]} ";
            }
            return result.ToString().TrimEnd();
        }
    }
}
