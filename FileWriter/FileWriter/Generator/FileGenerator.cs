using FileWriter.Crawler;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace FileWriter.Generator
{
    public class FileGenerator : IFileGenerator
    {
        private readonly ISentenceCrawler _sentenceCrawler;
        private readonly IBytesCrawler _bytesCrawler;

        public FileGenerator(ISentenceCrawler sentenceCrawler, IBytesCrawler bytesCrawler)
        {
            _sentenceCrawler = sentenceCrawler;
            _bytesCrawler = bytesCrawler;
        }

        public Report GenerateFile(string path, int fileSize, int bufferSize)
        {
            string fileName = $"{DateTime.Now.ToString("yyyy-MM-dd-HHmmss")}-arquivo-gerado.txt";

            string sentence = _sentenceCrawler.GetSentence();
            int bytes = _bytesCrawler.GetBytes(sentence);

            int bufferSizeBytes = bufferSize * 1048576;
            long fileSizeBytes = fileSize * 1048576;

            int iterations = bufferSizeBytes / bytes;
            int flushSizeBytes = iterations * bytes;

            long currentFileSizeBytes = 0;
            int counter = 0;

            Stopwatch watch = new Stopwatch();
            watch.Start();

            using (StreamWriter writer = new StreamWriter($@"{path}\{fileName}", false, Encoding.UTF8, bufferSizeBytes))
            {
                do
                {
                    for (int i = 0; i < iterations; i++)
                        writer.Write(sentence);

                    writer.Flush();
                    currentFileSizeBytes += flushSizeBytes;
                    counter++;

                } while (currentFileSizeBytes < fileSizeBytes);
            }

            watch.Stop();

            return new Report()
            {
                Name = fileName,
                Size = fileSize,
                Path = path,
                Iterations = counter,
                TotalTime = watch.Elapsed,
                AverageTime = watch.Elapsed / counter
            };
        }

        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _sentenceCrawler.Dispose();
                _bytesCrawler.Dispose();
            }
        }
    }
}
