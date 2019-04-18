using System;
using System.Collections.Generic;
using System.Linq;

namespace _5FilterByAge
{
    class FilterByAge
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> people = new Dictionary<string, int>();

            int peopleCount = int.Parse(Console.ReadLine());

            for (int currentPerson = 0; currentPerson < peopleCount; currentPerson++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int ages = int.Parse(input[1]);

                people.Add(name, ages);
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<int, bool> tester = CreateTester(condition, age);

            Action<KeyValuePair<string, int>> printer = CreatePrinter(format);

            PrintFilteredStudent(people, tester, printer);
        }

        private static void PrintFilteredStudent(Dictionary<string, int> people, Func<int, bool> tester, Action<KeyValuePair<string, int>> printer)
        {
            
        }

        private static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name": return person => Console.WriteLine(person.Key);
                case "age": return person => Console.WriteLine(person.Value);
                case "name age": return person => Console.WriteLine($"{person.Key} - {person.Value}");
                default: return null;
            }
        }

        private static Func<int, bool> CreateTester(string condition, int age)
        {
            switch (condition)
            {
                case "younger": return x => x < age;
                case "older": return x => x >= age;
                default: return null;
            }
        }
    }
}
