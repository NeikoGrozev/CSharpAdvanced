namespace Hospital
{
    using System;

    public class AddArgumentsInHospital
    {
        public static void Add(Hospital hospital)
        {
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Output")
                {
                    break;
                }

                string[] arguments = command
                    .Split();

                string departament = arguments[0];
                var firstName = arguments[1];
                var secondName = arguments[2];
                var patient = arguments[3];

                var fullName = firstName + " " + secondName;

                hospital.AddDepartment(departament);
                hospital.AddDoctor(firstName, secondName);
                hospital.AddPatient(departament, fullName, patient);
            }
        }
    }
}
