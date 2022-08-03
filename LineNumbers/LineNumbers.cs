namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;

    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\text.txt";
            string outputPath = @"..\..\..\output.txt";

            ProcessLines(inputPath, outputPath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            char[] checkArray = new char[] { '-', ',', '.', '!', '?', '\'' };
            string[] lines = File.ReadAllLines(inputFilePath);
            string[] outputLines = new string[lines.Length];

            int index = 0;
            foreach (string line in lines)
            {
                int chars = 0;
                int marks = 0;
                foreach (char c in line)
                {
                    if (char.IsLetter(c)) chars++;
                    if (checkArray.Contains(c)) marks++;
                }

                outputLines[index] = $"Line {++index}: {line} ({chars})({marks})";
            }

            File.WriteAllLines(outputFilePath, outputLines);
        }
    }
}
