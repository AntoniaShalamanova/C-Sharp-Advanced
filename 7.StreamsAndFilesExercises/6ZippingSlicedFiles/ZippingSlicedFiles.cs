using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace _6ZippingSlicedFiles
{
    class ZippingSlicedFiles
    {
        static List<string> partsDirectory = new List<string>();

        static void Main(string[] args)
        {
            Console.Write("Enter number of parts: ");
            int parts = int.Parse(Console.ReadLine());
            string fileToSlice = "../../../../sliceMe.mp4";
            string destinationDirectory = "../../../../";

            SliceAndCompress(fileToSlice, destinationDirectory, parts);
            DecompressAndAssemble(destinationDirectory);
        }

        private static void DecompressAndAssemble(string destinationDirectory)
        {
            FileStream writer = new FileStream(destinationDirectory + "decompressed.avi", FileMode.Create);
            using (writer)
            {
                foreach (var path in partsDirectory)
                {
                    GZipStream decompressor = new GZipStream(new FileStream(path, FileMode.Open),
                        CompressionMode.Decompress);
                    byte[] buffer = new byte[1024];
                    using (decompressor)
                    {
                        while (true)
                        {
                            int bytesCount = decompressor.Read(buffer, 0, buffer.Length);

                            if (bytesCount == 0)
                            {
                                break;
                            }

                            writer.Write(buffer, 0, bytesCount);
                        }
                    }
                }
            }
        }

        static void SliceAndCompress(string sourceFile, string destinationDirectory, int parts)
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
                        $"Part-{currentPart}.mp4.gz";

                    partsDirectory.Add(destinationPath);

                    GZipStream compressor = new GZipStream(new FileStream(destinationPath, FileMode.Create),
                        CompressionMode.Compress, false);

                    using (compressor)
                    {
                        reader.Read(buffer, 0, buffer.Length);

                        compressor.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
