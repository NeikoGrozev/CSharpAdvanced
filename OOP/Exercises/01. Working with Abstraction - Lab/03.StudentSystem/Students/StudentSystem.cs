namespace StudentSystem.Students
{
     using System.Collections.Generic;

    public class StudentSystem
    {
        private Dictionary<string, Student> studensRepository;

        public StudentSystem()
        {
            this.studensRepository = new Dictionary<string, Student>();
        }               

        public void Add(string name, int age, double grade)
        {
            if (!this.studensRepository.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                this.studensRepository[name] = student;
            }
        }

        public Student Get(string name)
        {
            if (this.studensRepository.ContainsKey(name))
            {
                var student = this.studensRepository[name];

                return student;
            }

            return null;
        }        
    }
}
