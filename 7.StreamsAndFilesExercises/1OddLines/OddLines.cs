using System;
using System.IO;

namespace _1OddLines
{
    class OddLines
    {
        static void Main(string[] args)
        {
            string path = "../../../../text.txt";

            StreamReader reader = new StreamReader(path);

            using (reader)
            {
                int rowNumber = 0;
                string currentRow = reader.ReadLine();

                while (currentRow != null)
                {
                    if (rowNumber % 2 != 0)
                    {
                        Console.WriteLine(currentRow);
                    }

                    rowNumber++;
                    currentRow = reader.ReadLine();
                }
            }
        }
    }
}
