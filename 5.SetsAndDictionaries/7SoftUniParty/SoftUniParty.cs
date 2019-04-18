using System;
using System.Collections.Generic;

namespace _7SoftUniParty
{
    class SoftUniParty
    {
        static void Main(string[] args)
        {
            HashSet<string> vip = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();


            string guest = Console.ReadLine();

            while (guest != "PARTY")
            {
                if (char.IsDigit(guest[0]))
                {
                    vip.Add(guest);
                }
                else if (guest.Length == 8)
                {
                    regular.Add(guest);
                }

                guest = Console.ReadLine();
            }

            guest = Console.ReadLine();

            while (guest != "END")
            {
                if (char.IsDigit(guest[0]))
                {
                    vip.Remove(guest);
                }
                else if (guest.Length == 8)
                {
                    regular.Remove(guest);
                }

                guest = Console.ReadLine();
            }

            Console.WriteLine(vip.Count + regular.Count);

            foreach (var person in vip)
            {
                Console.WriteLine(person);
            }

            foreach (var person in regular)
            {
                Console.WriteLine(person);
            }
        }
    }
}
