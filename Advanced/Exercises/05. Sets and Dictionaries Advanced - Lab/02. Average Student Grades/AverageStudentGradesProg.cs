namespace AverageStudentGrades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class AverageStudentGradesProg
    {
        static void Main()
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string[] student = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = student[0];
                double grade = double.Parse(student[1]);

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double>());
                }

                students[name].Add(grade);
            }

            foreach (var item in students)
            {
                Console.WriteLine($"{item.Key} -> {string.Join(" ", item.Value.Select(x => x.ToString("F2")))} (avg: {item.Value.Average():F2})");
            }
        }
    }
}
