using System;
using System.Collections.Generic;
using System.Linq;

namespace _8Ranking
{
    class Ranking
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            var students = new SortedDictionary<string, Dictionary<string, double>>();

            string input = Console.ReadLine();

            while (input != "end of contests")
            {
                string[] contestInfo = input
                    .Split(":", StringSplitOptions.RemoveEmptyEntries);

                string contest = contestInfo[0];
                string password = contestInfo[1];

                contests[contest] = password;

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "end of submissions")
            {
                string[] contestInfo = input
                    .Split(new char[] { '=', '>' }, StringSplitOptions.RemoveEmptyEntries);

                string contest = contestInfo[0];
                string password = contestInfo[1];
                string username = contestInfo[2];
                double points = double.Parse(contestInfo[3]);

                if (!contests.ContainsKey(contest))
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (contests[contest] != password)
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (!students.ContainsKey(username))
                {
                    students[username] = new Dictionary<string, double>();
                }

                if (!students[username].ContainsKey(contest))
                {
                    students[username][contest] = 0;
                }

                if (students[username][contest] < points)
                {
                    students[username][contest] = points;
                }

                input = Console.ReadLine();
            }

            //double bestResult = students.Max(x => x.Value.Values.Sum());
            var bestStudent = students.OrderByDescending(x=>x.Value.Values.Sum())
                .FirstOrDefault();

            Console.WriteLine($"Best candidate is {bestStudent.Key} with total {bestStudent.Value.Values.Sum()} points.");
            Console.WriteLine("Ranking: ");

            foreach (var student in students)
            {
                Console.WriteLine(student.Key);

                foreach (var contest in student.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
