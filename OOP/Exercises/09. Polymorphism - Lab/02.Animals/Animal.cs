namespace Animals
{
    public abstract class Animal
    {
        public string name;

        public string favouriteFood;

        public virtual string ExplainSelf()
        {
            return $"I am {this.name} and my fovourite food is {this.favouriteFood}";
        }
    }
}