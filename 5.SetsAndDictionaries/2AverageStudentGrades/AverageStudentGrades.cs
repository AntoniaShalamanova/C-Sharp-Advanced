using System;
using System.Collections.Generic;
using System.Linq;

namespace _2AverageStudentGrades
{
    class AverageStudentGrades
    {
        static void Main(string[] args)
        {
            int studentsNumber = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> studentsGrades = new Dictionary<string, List<double>>();

            for (int currentStudent = 0; currentStudent < studentsNumber; currentStudent++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string student = input[0];
                double studentGrade = double.Parse(input[1]);

                if (!studentsGrades.ContainsKey(student))
                {
                    studentsGrades[student] = new List<double>();
                }

                studentsGrades[student].Add(studentGrade);
            }

            foreach (var student in studentsGrades)
            {
                string grades = string.Join(" ", student.Value.Select(x => x.ToString("F2")));
                Console.WriteLine($"{student.Key} -> {grades} (avg: {student.Value.Average():F2})");
            }
        }
    }
}
