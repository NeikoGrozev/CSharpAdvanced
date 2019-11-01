namespace Hospital
{
    using System;
    using System.Linq;

    public class PrintInfo
    {
        public static void Print(Hospital hospital)
        {
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] arguments = command
                    .Split();

                if (arguments.Length == 1)
                {
                    string findingDepartment = arguments[0];
                    Department currentDepartment = hospital.Departments.FirstOrDefault(dep => dep.Name == findingDepartment);

                    Console.WriteLine(currentDepartment);
                }
                else if (arguments.Length == 2 && int.TryParse(arguments[1], out int room))
                {
                    string findingDepartment = arguments[0];
                    Department currentDepartment = hospital.Departments.FirstOrDefault(dep => dep.Name == findingDepartment);
                    Room currentRoom = currentDepartment.Rooms[room - 1];

                    Console.WriteLine(currentRoom);
                }
                else
                {
                    string firstName = arguments[0];
                    string secondName = arguments[1];
                    string fullName = firstName + " " + secondName;

                    Doctor currentDoctor = hospital.Doctors.FirstOrDefault(d => d.FullName == fullName);

                    Console.WriteLine(currentDoctor);
                }
            }
        }
    }
}
