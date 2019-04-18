using System;
using System.Collections.Generic;

namespace _1UniqueUsernames
{
    class UniqueUsernames
    {
        static void Main(string[] args)
        {
            int userCount = int.Parse(Console.ReadLine());
            HashSet<string> uniqueUsernames = new HashSet<string>();

            for (int currentUser = 0; currentUser < userCount; currentUser++)
            {
                string input = Console.ReadLine();

                uniqueUsernames.Add(input);
            }

            foreach (var user in uniqueUsernames)
            {
                Console.WriteLine(user);
            }
        }
    }
}
