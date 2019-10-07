namespace DefiningClasses
{
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        private List<Person> familyMembers;

        public Family()
        {
            familyMembers = new List<Person>();
        }

        public void AddMember(Person member)
        {
            familyMembers.Add(member);
        }

        public List<Person> GetOldestPeople()
        {
            List<Person> oldestPerson = familyMembers.Where(p => p.Age > 30).ToList();

            return oldestPerson;
        }
    }
}