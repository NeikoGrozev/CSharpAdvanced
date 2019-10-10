namespace BoxOfT
{
    using System.Collections.Generic;
    using System.Linq;

    public class Box<T>
    {
        private List<T> boxs;

        public Box()
        {
            this.boxs = new List<T>();
        }

        public int Count
        {
            get
            {
                int count = boxs.Count;
                return count;
            }
        }

        public void Add(T number)
        {
            this.boxs.Add(number);
        }

        public T Remove()
        {
            var topmostElement = this.boxs.Last();
            this.boxs.RemoveAt(boxs.Count - 1);

            return topmostElement;
        }

    }
}
