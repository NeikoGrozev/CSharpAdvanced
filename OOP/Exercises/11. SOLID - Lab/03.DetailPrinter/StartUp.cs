namespace DetailPrinter
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            Employee ivan = new Employee("Ivan");
           

            List<string> doc = new List<string>
            {
                "Project",
                "Employees",
                "Salarys"
            };
            Manager pesho = new Manager("Pesho", doc);
            
            List<Employee> emp = new List<Employee>
            {
                ivan,
                pesho
            };

            DetailsPrinter print = new DetailsPrinter(emp);
            print.PrintDetails();
        }
    }
}