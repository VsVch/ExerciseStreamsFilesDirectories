namespace EvenLines
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class EvenLines
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            

            StringBuilder sb = new StringBuilder();
            using StreamReader reader = new StreamReader(inputFilePath);

            int idx = 0;
            string line = reader.ReadLine();
            while (line != null)
            {
                if (idx++ % 2 == 0)
                {
                    string reversedLine = ReverseWords(line);
                    string replaceLine = ReplaceSymbols(reversedLine);

                    Console.WriteLine(replaceLine);
                }

                line = reader.ReadLine();
            }

            return sb.ToString();


        }
        private static string ReverseWords(string replacedSymbols)
        {
            Stack<string> stack = new Stack<string>(replacedSymbols.Split());
            StringBuilder sb = new StringBuilder();
            while (stack.Count > 0) sb.Append($"{stack.Pop()} ");

            return sb.ToString();
        }

        private static string ReplaceSymbols(string reversedLine)
        {
            char[] replaceChars = new char[] { '-', ',', '.', '!', '?' };
            foreach (char c in replaceChars)
                reversedLine = reversedLine.Replace(c, '@');

           

            return reversedLine;
        }
    }

}
