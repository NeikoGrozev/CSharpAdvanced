namespace CustomStack
{
    using System.Collections.Generic;

    public class StackOfStrings : Stack<string>
    {

        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public Stack<string> AddRange(List<string> collection)
        {
            foreach (var item in collection)
            {
                this.Push(item);
            }

            return this;
        }
    }
}
