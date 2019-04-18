using System;
using System.IO;

namespace _4CopyBinaryFile
{
    class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            var imageToCopy = new FileStream("../../../../copyMe.png", FileMode.Open);

            using (imageToCopy)
            {
                var destination = new FileStream("../../../../copyImage.png", FileMode.Create);

                using (destination)
                {
                    while (true)
                    {
                        long size = imageToCopy.Length;
                        byte[] buffer = new byte[size];
                        int readBytes = imageToCopy.Read(buffer, 0, buffer.Length);

                        if (readBytes == 0)
                        {
                            break;
                        }

                        destination.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
