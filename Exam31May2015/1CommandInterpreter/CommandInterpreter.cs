using System;
using System.Collections.Generic;
using System.Linq;

namespace _1CommandInterpreter
{
    class CommandInterpreter
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                    .Split(' ')
                    .ToList();


            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] tokens = input
                    .Split(' ');

                string command = tokens[0];
                int startIndx = 0;
                int count = 0;

                switch (command)
                {
                    case "reverse":
                        startIndx = int.Parse(tokens[2]);
                        count = int.Parse(tokens[4]);
                        if (!IsValid(words.Count, startIndx, count))
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        words.Reverse(startIndx, count);
                        break;

                    case "sort":
                        startIndx = int.Parse(tokens[2]);
                        count = int.Parse(tokens[4]);
                        if (!IsValid(words.Count, startIndx, count))
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        words.Sort(startIndx, count, null);
                        break;

                    case "rollLeft":
                        count = int.Parse(tokens[1]);
                        if (count < 0)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        RollLeft(words, count);
                        break;

                    case "rollRight":
                        count = int.Parse(tokens[1]);
                        if (count < 0)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        RollRight(words, count);
                        break;

                    default:
                        Console.WriteLine("Invalid input parameters.");
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"[{string.Join(", ", words)}]");
        }

        private static bool IsValid(int wordsCount, int startIndx, int count)
        {
            if (startIndx < 0 || startIndx > wordsCount - 1)
            {
                return false;
            }
            else if (count < 0 || count > wordsCount - startIndx)
            {
                return false;
            }

            return true;
        }

        private static void RollRight(List<string> words, int count)
        {
            count %= words.Count;

            for (int i = 0; i < count; i++)
            {
                string lastWord = words[words.Count - 1];

                for (int currentWord = words.Count - 1; currentWord >= 1; currentWord--)
                {
                    words[currentWord] = words[currentWord - 1];
                }

                words[0] = lastWord;
            }
        }

        private static void RollLeft(List<string> words, int count)
        {
            count %= words.Count;

            for (int i = 0; i < count; i++)
            {
                string firstWord = words[0];

                for (int currentWord = 0; currentWord < words.Count - 1; currentWord++)
                {
                    words[currentWord] = words[currentWord + 1];
                }

                words[words.Count - 1] = firstWord;
            }
        }
    }
}
