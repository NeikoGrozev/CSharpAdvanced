namespace CollectionHierarchy
{
    using System.Collections.Generic;

    public class AddCollection : IAddable
    {
        public AddCollection()
        {
            Collection = new List<string>();
        }

        public int Index { get; private set; } = 0;

        public List<string> Collection { get; protected set; }

        public virtual int Add(string item)
        {
            Collection.Insert(Index, item);

            return Index++;
        }

        public virtual string Remove()
        {
            return "";
        }
    }
}