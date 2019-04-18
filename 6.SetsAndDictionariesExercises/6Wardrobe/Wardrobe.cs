using System;
using System.Collections.Generic;

namespace _6Wardrobe
{
    class Wardrobe
    {
        static void Main(string[] args)
        {
            int linesNumber = int.Parse(Console.ReadLine());

            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int currentInput = 0; currentInput < linesNumber; currentInput++)
            {
                string[] input = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string color = input[0];
                string[] items = input[1]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries);

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }

                for (int i = 0; i < items.Length; i++)
                {
                    string item = items[i];

                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color][item] = 0;
                    }

                    wardrobe[color][item]++;
                }
            }

            string[] serchedCI = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string serchedColor = serchedCI[0];
            string serchedItem = serchedCI[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var item in color.Value)
                {
                    if (color.Key == serchedColor && item.Key == serchedItem)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
