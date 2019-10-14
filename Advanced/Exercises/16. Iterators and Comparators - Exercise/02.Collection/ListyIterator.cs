namespace ListIterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> collection;

        private int index;

        public ListyIterator()
        {
            this.collection = new List<T>();
            this.index = 0;
        }

        public void Create(List<T> addCollection)
        {
            this.collection = addCollection;
        }       

        public bool HasNext()
        {
            if (index + 1 < this.collection.Count)
            {
                return true;
            }

            return false;
        }

        public bool Move()
        {
            if (HasNext())
            {
                this.index++;

                return true;
            }

            return false;
        }

        public string PrintAll()
        {
            string result = string.Empty;

            foreach (var item in this.collection)
            {
                result += $"{item} ";
            }

            return result.TrimEnd();
        }

        public string Print()
        {
            if (this.collection.Count <= 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }

            return this.collection[index].ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.collection.Count; i++)
            {
                yield return this.collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();
    }
}
