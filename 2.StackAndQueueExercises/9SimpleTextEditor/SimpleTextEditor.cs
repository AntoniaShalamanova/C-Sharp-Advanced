using System;
using System.Collections.Generic;

namespace _9SimpleTextEditor
{
    class SimpleTextEditor
    {
        static void Main(string[] args)
        {
            int operationsCount = int.Parse(Console.ReadLine());

            Stack<string> operations = new Stack<string>();

            string text = "";
            operations.Push(text);

            for (int i = 0; i < operationsCount; i++)
            {
                string[] currentOperation = Console.ReadLine().Split(' ');

                string commandType = currentOperation[0];

                switch (commandType)
                {
                    case "1":
                        text += currentOperation[1];

                        operations.Push(text);
                        break;

                    case "2":
                        int symbolsToRemove = int.Parse(currentOperation[1]);
                        text = text.Remove(text.Length - symbolsToRemove);

                        operations.Push(text);
                        break;

                    case "3":
                        int indx = int.Parse(currentOperation[1]);

                        Console.WriteLine(text[indx - 1]);
                        break;

                    case "4":
                        operations.Pop();
                        text = operations.Peek();
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
