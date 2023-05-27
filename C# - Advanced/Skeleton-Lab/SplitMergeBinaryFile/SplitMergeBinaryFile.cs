namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using (FileStream sourceFile = File.OpenRead(sourceFilePath))
            {
                int fileSize = (int)sourceFile.Length;
                int partOneSize = fileSize / 2;
                int partTwoSize = fileSize - partOneSize;

                byte[] buffer = new byte[fileSize];

                // Read the source file into the buffer
                sourceFile.Read(buffer, 0, fileSize);

                // Create the first part file
                using (FileStream partOneFile = File.Create(partOneFilePath))
                {
                    partOneFile.Write(buffer, 0, partOneSize);
                }

                // Create the second part file
                using (FileStream partTwoFile = File.Create(partTwoFilePath))
                {
                    partTwoFile.Write(buffer, partOneSize, partTwoSize);
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream partOneFile = File.OpenRead(partOneFilePath))
            using (FileStream partTwoFile = File.OpenRead(partTwoFilePath))
            using (FileStream joinedFile = File.Create(joinedFilePath))
            {
                // Copy the contents of the first part file to the joined file
                partOneFile.CopyTo(joinedFile);

                // Copy the contents of the second part file to the joined file
                partTwoFile.CopyTo(joinedFile);
            }
        }
    }
}