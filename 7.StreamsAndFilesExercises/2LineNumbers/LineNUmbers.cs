using System;
using System.IO;

namespace LineNumbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            string path = "../../../../text.txt";

            StreamReader reader = new StreamReader(path);
            StreamWriter writer = new StreamWriter("../../../../output.txt");

            using (reader)
            {
                using (writer)
                {
                    int rowNumber = 1;
                    string currentRow = reader.ReadLine();

                    while (currentRow != null)
                    {
                        writer.WriteLine($"Line {rowNumber}: {currentRow}");

                        rowNumber++;
                        currentRow = reader.ReadLine();
                    }
                }
            }
        }
    }
}
