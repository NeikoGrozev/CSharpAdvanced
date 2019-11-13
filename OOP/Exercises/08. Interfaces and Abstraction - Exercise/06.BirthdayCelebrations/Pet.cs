namespace BirthdayCelebrations
{
    public class Pet : Society, IPet, IBirthdate
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name { get; set; }
        public string Birthdate { get; set; }

        public override bool FindingYear(string year)
        {
            if (this.Birthdate.EndsWith(year))
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"{this.Birthdate}";
        }
    }
}