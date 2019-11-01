namespace Hospital
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Department
    {
        private const int roomsCapacity = 20;

        public Department(string name)
        {
            this.Name = name;
            this.Rooms = new List<Room>();
            CreateRooms();
        }

        public string Name { get; private set; }

        public List<Room> Rooms { get; private set; }

        private void CreateRooms()
        {
            for (int i = 0; i < roomsCapacity; i++)
            {
                this.Rooms.Add(new Room());
            }
        }

        public void AddPatientInRoom(Patient patient)
        {
            Room currentRoom = this.Rooms.FirstOrDefault(r => !r.RoomIsFull);

            if (currentRoom != null)
            {
                currentRoom.Patients.Add(patient);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var room in this.Rooms)
            {
                foreach (var patient in room.Patients)
                {
                    sb.AppendLine(patient.Name);
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
