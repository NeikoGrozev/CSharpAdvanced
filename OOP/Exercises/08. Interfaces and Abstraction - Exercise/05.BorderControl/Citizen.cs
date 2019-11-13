namespace BorderControl
{
    public class Citizen : Society, ICitizen, IId
    {
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }

        public override bool FindingFakeId(string number)
        {
            if(this.Id.EndsWith(number))
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"{this.Id}";
        }
    }
}
