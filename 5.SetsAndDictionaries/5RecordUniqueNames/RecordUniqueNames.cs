using System;
using System.Collections.Generic;

namespace _5RecordUniqueNames
{
    class RecordUniqueNames
    {
        static void Main(string[] args)
        {
            HashSet<string> names = new HashSet<string>();

            int namesNumber = int.Parse(Console.ReadLine());

            for (int currentName = 0; currentName < namesNumber; currentName++)
            {
                string name = Console.ReadLine();

                names.Add(name);
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
