namespace CustomDataStructure
{
    using System;

    public class CustomList
    {
        private const int InitialCapacity = 2;

        private int[] items;

        public CustomList()
        {
            this.items = new int[InitialCapacity];
            this.Count = 0;
        }

        public int Count { get; set; }

        public int this[int index]
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
        public void Add(int item)
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
                this.items[Count - 1] = default(int);
                this.Count--;
            }

            if (this.Count <= this.items.Length / 4)
            {
                Shrink();
            }
        }

        public void Insert(int index, int item)
        {
            if (CorrectIndex(index))
            {
                ShiftToRigth(index);
                this.items[index] = item;
                this.Count++;
            }
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (item == this.items[i])
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
                int item = this.items[firstIndex];
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
                throw new ArgumentOutOfRangeException("Index is out ot range!");
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
