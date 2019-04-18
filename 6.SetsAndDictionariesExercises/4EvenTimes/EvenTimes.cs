using System;
using System.Collections.Generic;
using System.Linq;

namespace _4EvenTimes
{
    class EvenTimes
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> counter = new Dictionary<int, int>();

            int numbersCount = int.Parse(Console.ReadLine());

            for (int currentNumb = 0; currentNumb < numbersCount; currentNumb++)
            {
                int numb = int.Parse(Console.ReadLine());

                if (!counter.ContainsKey(numb))
                {
                    counter[numb] = 0;
                }

                counter[numb]++;
            }

            Console.WriteLine(counter.Where(x => x.Value % 2 == 0).FirstOrDefault().Key);
        }
    }
}
