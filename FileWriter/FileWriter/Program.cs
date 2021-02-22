using FileWriter.Configuration;
using FileWriter.Crawler;
using FileWriter.Generator;
using System;
using System.Text;

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

            Report report;

            using (SentenceCrawler sentenceCrawler = new SentenceCrawler())
            {
                using (BytesCrawler bytesCrawler = new BytesCrawler())
                {
                    using (FileGenerator fileGenerator = new FileGenerator(sentenceCrawler, bytesCrawler))
                    {
                        report = fileGenerator.GenerateFile(path, fileSize, bufferSize);
                    }
                }
            }

            StringBuilder reportBuilder = new StringBuilder();
            reportBuilder.AppendLine($"Nome: {report.Name}");
            reportBuilder.AppendLine($"Tamanho: {report.Size}mb");
            reportBuilder.AppendLine($"Path: {report.Path}");
            reportBuilder.AppendLine($"Iterações: {report.Iterations}");
            reportBuilder.AppendLine($"Tempo Total: {report.TotalTime}");
            reportBuilder.AppendLine($"Tempo Médio: {report.AverageTime}");

            Console.WriteLine(reportBuilder);
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadLine();
        }
    }
}
