using FileWriter.Crawler;
using System;
using System.IO;
using System.Text;

namespace FileWriter.Generator
{
    public class FileGenerator : IFileGenerator
    {
        private readonly IWebCrawler _webCrawler;

        public FileGenerator(IWebCrawler webCrawler)
        {
            _webCrawler = webCrawler;
        }

        public void GenerateFile(string path, int fileSize, int bufferSize)
        {
            string sentence = _webCrawler.GetSentence();
            int bytes = _webCrawler.GetBytes(sentence);

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

        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _webCrawler.Dispose();
            }
        }
    }
}
