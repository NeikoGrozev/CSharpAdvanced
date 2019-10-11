namespace GenericCountMethodString
{
    using System;
    using System.Collections.Generic;

    public class Box<T>
        where T:IComparable<T>
    {
        private List<T> boxCollection;

        public Box()
        {
            this.boxCollection = new List<T>();
        }

        public void Add(T item)
        {
            this.boxCollection.Add(item);
        }

        public int Count(T item)
        {
            int count = 0;

            foreach (var box in boxCollection)
            {
                if (box.CompareTo(item) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
