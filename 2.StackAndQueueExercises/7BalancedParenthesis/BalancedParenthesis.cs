using System;
using System.Collections.Generic;

namespace _7BalancedParenthesis
{
    class BalancedParenthesis
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> brackets = new Stack<char>();

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("No");
                return;
            }

            foreach (var currentBracket in input)
            {
                bool isOpenBracket =  currentBracket == '('
                    || currentBracket == '['
                    || currentBracket == '{';

                if (isOpenBracket)
                {
                    brackets.Push(currentBracket);
                }
                else
                {
                    if (brackets.Count != 0  && currentBracket == ')' && brackets.Peek() == '(')
                    {
                        brackets.Pop();
                    }
                    else if (brackets.Count != 0 && currentBracket == ']' && brackets.Peek() == '[')
                    {
                        brackets.Pop();
                    }
                    else if (brackets.Count != 0 && currentBracket == '}' && brackets.Peek() == '{')
                    {
                        brackets.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }


            Console.WriteLine("YES");
        }
    }
}
