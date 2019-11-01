namespace Hospital
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Doctor
    {
        public Doctor(string firstName, string secondName)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Patients = new List<Patient>();
        }

        public string FirstName { get; private set; }

        public string SecondName { get; private set; }

        public string FullName => this.FirstName + " " + this.SecondName;

        public List<Patient> Patients { get; private set; }

        public void AddPatient(Patient name)
        {
            this.Patients.Add(name);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var patient in this.Patients.OrderBy(p => p.Name))
            {
                sb.AppendLine(patient.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
