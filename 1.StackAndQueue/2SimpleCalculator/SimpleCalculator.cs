using System;
using System.Collections.Generic;
using System.Linq;

namespace _2SimpleCalculator
{
    class SimpleCalculator
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<string> operands = new Stack<string>(input.Split(' ').Reverse());

            while (operands.Count != 1)
            {
                int firstNumb = int.Parse(operands.Pop());
                string sign = operands.Pop();
                int secondNumb = int.Parse(operands.Pop());

                switch(sign)
                {
                    case "+":
                        operands.Push((firstNumb + secondNumb).ToString());
                        break;
                    case "-":
                        operands.Push((firstNumb - secondNumb).ToString());
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(operands.Pop());
        }
    }
}
