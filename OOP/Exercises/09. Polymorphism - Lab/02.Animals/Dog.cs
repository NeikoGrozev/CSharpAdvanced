﻿namespace Animals
{
    using System.Text;

    public class Dog : Animal
    {
        public Dog(string name, string favouriteFood)
        {
            this.name = name;
            this.favouriteFood = favouriteFood;
        }

        public override string ExplainSelf()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ExplainSelf());
            sb.AppendLine("DJAAF");

            return sb.ToString().TrimEnd();
        }
    }
}