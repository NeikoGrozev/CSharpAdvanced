namespace BirthdayCelebrations
{
    using System;

    public class Citizen : Society, ICitizen, IId, IBirthdate
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Id { get; set; }

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