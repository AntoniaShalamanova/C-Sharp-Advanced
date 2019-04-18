using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3WordCount
{
    class WordCount
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordsCounter = new Dictionary<string, int>();
            StreamWriter writer = new StreamWriter("../../../../result.txt");
            StreamReader reader = new StreamReader("../../../../words.txt");

            using (reader)
            {
                string currentWord = reader.ReadLine();

                while (currentWord != null)
                {
                    wordsCounter[currentWord] = 0;

                    currentWord = reader.ReadLine();
                }
            }

            reader = new StreamReader("../../../../text.txt");

            using (reader)
            {
                string pattern = @"[A-z]+";
                string words = reader.ReadToEnd();
                MatchCollection matchedWords = Regex.Matches(words, pattern);

                foreach (var word in matchedWords)
                {
                    string currentWord = word.ToString().ToLower();
                    if (wordsCounter.ContainsKey(currentWord))
                    {
                        wordsCounter[currentWord]++;
                    }
                }
            }

            using (writer)
            {
                foreach (var pair in wordsCounter.OrderByDescending(p=>p.Value))
                {
                    writer.WriteLine($"{pair.Key} - {pair.Value}");
                }
            }
        }
    }
}
