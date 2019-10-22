using System.Collections.Generic;

namespace Repository
{
    public class Repository
    {
        private List<Person> persons;

        public Repository()
        {
            this.persons = new List<Person>();
        }

        public int Count { get; private set; }

        public void Add(Person person)
        {
            this.persons.Add(person);
            this.Count++;
        }

        public Person Get(int ID)
        {
            Person person = persons[ID];

            return person;
        }

        public bool Update(int ID, Person person)
        {
            if (ID >= 0 && ID < persons.Count)
            {
                this.persons[ID] = person;
                return true;
            }

            return false;
        }

        public bool Delete(int ID)
        {
            if (ID >= 0 && ID < persons.Count)
            {
                this.persons.RemoveAt(ID);
                this.Count--;

                return true;
            }

            return false;
        }
    }
}
