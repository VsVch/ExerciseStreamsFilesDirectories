using System.IO;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\copyMe.png";
            string outputPath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputPath, outputPath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using FileStream reader = new FileStream(inputFilePath, FileMode.Open);
            using FileStream writer = new FileStream(outputFilePath, FileMode.Create);
            byte[] bytes = new byte[256];
            while (true)
            {
                int curBytes = reader.Read(bytes, 0, bytes.Length);
                if (curBytes == 0)
                {
                    break;
                }
                writer.Write(bytes,0,bytes.Length);

            }

        }
    }
}
