using System;
using System.Collections.Generic;
using System.IO;

namespace _5SlicingFile
{
    class Program
    {
        static List<string> partsDirectory = new List<string>();

        static void Main(string[] args)
        {
            Console.Write("Enter number of parts: ");
            int parts = int.Parse(Console.ReadLine());
            string fileToSlice = "../../../../sliceMe.mp4";
            string destinationDirectory = "../../../../";

            Slice(fileToSlice, destinationDirectory, parts);
            Assemble(destinationDirectory);
        }

        private static void Assemble(string destinationDirectory)
        {
            FileStream writer = new FileStream(destinationDirectory + "assembled.avi", FileMode.Create);
            using (writer)
            {
                foreach (var path in partsDirectory)
                {
                    FileStream reader = new FileStream(path, FileMode.Open);
                    byte[] buffer = new byte[reader.Length];
                    using (reader)
                    {
                        reader.Read(buffer, 0, buffer.Length);

                        writer.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }

        static void Slice(string sourceFile, string destinationDirectory, int parts)
        {

            FileStream reader = new FileStream(sourceFile, FileMode.Open);

            using (reader)
            {
                long size = reader.Length / parts +
                    reader.Length % parts;

                byte[] buffer = new byte[size];

                for (int currentPart = 0; currentPart < parts; currentPart++)
                {
                    string destinationPath = destinationDirectory +
                        $"Part-{currentPart}.mp4";

                    partsDirectory.Add(destinationPath);

                    FileStream writer = new FileStream(destinationPath, FileMode.Create);
                    using (writer)
                    {
                        reader.Read(buffer, 0, buffer.Length);

                        writer.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
