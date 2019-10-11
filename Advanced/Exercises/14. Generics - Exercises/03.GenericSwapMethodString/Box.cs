namespace GenericSwapMethodString
{
    using System.Collections.Generic;
    using System.Text;

    public class Box<T>
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

        public void Swap(int firstIndex, int secondIndex)
        {
            T temp = this.boxCollection[firstIndex];
            this.boxCollection[firstIndex] = this.boxCollection[secondIndex];
            this.boxCollection[secondIndex] = temp;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in boxCollection)
            {
                sb.AppendLine($"{item.GetType().FullName}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
