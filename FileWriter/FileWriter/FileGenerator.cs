using System;
using System.IO;
using System.Text;

namespace FileWriter
{
    public static class FileGenerator
    {
        public static void GenerateFile(string path, int fileSize, int bufferSize)
        {
            string sentence = WebCrawler.GetSentence();
            int bytes = WebCrawler.GetBytes(sentence);

            int bufferSizeBytes = bufferSize * 1048576;
            long fileSizeBytes = fileSize * 1048576;

            int iterations = bufferSizeBytes / bytes;
            int flushSizeBytes = iterations * bytes;
            long currentFileSizeBytes = 0;

            string currentDateTime = DateTime.Now.ToString("yyyy-MM-dd-HHmmss");

            using (StreamWriter writer = new StreamWriter($@"{path}\{currentDateTime}-arquivo-gerado.txt", false, Encoding.UTF8, bufferSizeBytes))
            {
                do
                {
                    for (int i = 0; i < iterations; i++)
                        writer.Write(sentence);

                    writer.Flush();
                    currentFileSizeBytes += flushSizeBytes;

                } while (currentFileSizeBytes < fileSizeBytes);
            }
        }
    }
}
