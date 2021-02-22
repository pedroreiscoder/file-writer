using FileWriter.Configuration;
using FileWriter.Crawler;
using FileWriter.Generator;
using System;

namespace FileWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------- Gerador de Arquivos ---------------");

            string path = PathConfiguration.GetPath();
            int fileSize = FileSizeConfiguration.GetFileSize();
            int bufferSize = BufferSizeConfiguration.GetBufferSize();

            ISentenceCrawler sentenceCrawler = new SentenceCrawler();
            IBytesCrawler bytesCrawler = new BytesCrawler();
            Report report;

            using (FileGenerator fileGenerator = new FileGenerator(sentenceCrawler, bytesCrawler))
                report = fileGenerator.GenerateFile(path, fileSize, bufferSize);

            Console.WriteLine(report);
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadLine();
        }
    }
}
