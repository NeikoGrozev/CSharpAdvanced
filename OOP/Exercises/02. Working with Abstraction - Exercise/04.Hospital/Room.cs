namespace Hospital
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Room
    {
        private const int capacity = 3;

        public Room()
        {
            this.Patients = new List<Patient>();
        }

        public List<Patient> Patients { get; private set; }

        public bool RoomIsFull => this.Patients.Count == capacity;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var patient in this.Patients.OrderBy(n => n.Name))
            {
                sb.AppendLine(patient.Name);
            }
            return sb.ToString().TrimEnd();
        }
    }
}
