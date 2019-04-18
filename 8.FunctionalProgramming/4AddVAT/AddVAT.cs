using System;
using System.Linq;

namespace _4AddVAT
{
    class AddVAT
    {
        static void Main(string[] args)
        {
            Func<double, double> addVAT = n => n + n * 0.2;
            Func<double, string> format = n => n.ToString("F2");

            Console.WriteLine(string.Join(System.Environment.NewLine,
                Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .Select(addVAT)
                    .Select(format)
                    ));
        }
    }
}
