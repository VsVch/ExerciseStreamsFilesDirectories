namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string[] files = Directory.GetFiles(inputFolderPath, "*");
            Dictionary<string, Dictionary<string, double>> filesInfo
                = new Dictionary<string, Dictionary<string, double>>();

            foreach (string file in files)
            {
                FileInfo info = new FileInfo(file);
                string name = info.Name;
                string extension = info.Extension;
                double size = info.Length / 1024.0;

                if (!filesInfo.ContainsKey(extension))
                    filesInfo.Add(extension, new Dictionary<string, double>());
                filesInfo[extension].Add(name, size);
            }

            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, Dictionary<string, double>> kvp in filesInfo
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                sb.AppendLine(kvp.Key);
                foreach (KeyValuePair<string, double> innerKvp in kvp.Value
                    .OrderBy(x => x.Value))
                {
                    sb.AppendLine($"--{innerKvp.Key} - {innerKvp.Value:f3}kb");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            //File.WriteAllText(path, textContent);
        }

    }
}
