namespace Hospital
{
    using System.Collections.Generic;
    using System.Linq;

    public class Hospital
    {
        public Hospital()
        {
            this.Departments = new List<Department>();
            this.Doctors = new List<Doctor>();
        }

        public List<Department> Departments { get; private set; }

        public List<Doctor> Doctors { get; private set; }

        public void AddPatient(string departmentName, string doctorName, string patientName)
        {
            Department currentDepartment = this.Departments.FirstOrDefault(dep => dep.Name == departmentName);
            Doctor currentDoctor = this.Doctors.FirstOrDefault(d => d.FullName == doctorName);

            Patient patient = new Patient(patientName);

            currentDepartment.AddPatientInRoom(patient);
            currentDoctor.AddPatient(patient);
        }

        public void AddDoctor(string firstName, string secondName)
        {
            if (!this.Doctors.Any(d => d.FullName == firstName + " " + secondName))
            {
                Doctor doctor = new Doctor(firstName, secondName);
                this.Doctors.Add(doctor);

            }
        }

        public void AddDepartment(string name)
        {
            if (!this.Departments.Any(dep => dep.Name == name))
            {
                Department department = new Department(name);
                this.Departments.Add(department);
            }
        }
    }
}
