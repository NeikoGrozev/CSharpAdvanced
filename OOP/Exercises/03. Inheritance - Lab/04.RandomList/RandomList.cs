namespace CustomRandomList
{
    using System;
    using System.Collections.Generic;

    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random rnd = new Random();

            int index = rnd.Next(0, this.Count);
            string str = this[index];
            this.RemoveAt(index);

            return str;
        }
    }
}
