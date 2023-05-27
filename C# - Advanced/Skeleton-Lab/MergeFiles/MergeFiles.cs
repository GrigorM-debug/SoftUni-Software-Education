namespace MergeFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            var lines = new List<string>();

            using (StreamReader reader= new StreamReader(firstInputFilePath))
            {
                using (StreamReader reader1 = new StreamReader(secondInputFilePath))
                {
                    string rowOne = reader.ReadLine();
                    string rowTwo = reader1.ReadLine();

                    while (rowOne != null || rowTwo != null)
                    {
                        lines.Add(rowOne);

                        if (rowTwo != null)
                        {
                            lines.Add(rowTwo);
                        }

                        rowOne = reader.ReadLine();
                        rowTwo = reader1.ReadLine();
                    }
                }
            }
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var line in lines)
                {
                    writer.WriteLine(line);
                }
            }
        }
    }
}
