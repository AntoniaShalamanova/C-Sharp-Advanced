using System;
using System.Linq;

namespace _3CountUppercaseWords
{
    class CountUppercaseWords
    {
        static void Main(string[] args)
        {
            Func<string, bool> isUpper = x => x[0] == char.ToUpper(x[0]);


            Console.WriteLine(string.Join(System.Environment.NewLine, Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Where(isUpper)));
        }
    }
}
