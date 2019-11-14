namespace FoodShortage
{
    public class Rebel : IRebel, IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }
        public int Food { get; set; }

        public void BuyFood()
        {
            this.Food += 5;
        }

        void BuyFood(int sum)
        {
            this.Food += 5;
        }
    }
}