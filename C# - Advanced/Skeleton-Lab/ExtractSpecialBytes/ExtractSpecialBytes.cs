namespace ExtractSpecialBytes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using (StreamReader reader = new StreamReader(bytesFilePath))
            {
                byte[] fileBytes = File.ReadAllBytes(binaryFilePath);
                var bytesList = new List<String>();
                var sb = new StringBuilder();

                while (!reader.EndOfStream)
                {
                    bytesList.Add(reader.ReadLine());
                }
                foreach (var item in fileBytes)
                {
                    if (bytesList.Contains(item.ToString()))
                    {
                        sb.AppendLine(item.ToString());
                    }
                }

                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    writer.WriteLine(sb.ToString());
                }
            }
        }
    }
}
