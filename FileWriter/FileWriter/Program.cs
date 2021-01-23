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

            Console.Write("Informe o path de escrita do arquivo: ");
            string path = Console.ReadLine();

            while (string.IsNullOrEmpty(path))
            {
                Console.WriteLine("O path para escrita do arquivo é obrigatório!");
                Console.Write("Informe o path de escrita do arquivo: ");
                path = Console.ReadLine();
            }

            Console.WriteLine("Você deseja alterar o tamanho padrão do arquivo (100MB): s ou n");
            string changeFileSize = Console.ReadLine();

            int fileSize = 100;

            if (changeFileSize == "s")
            {
                Console.Write("Informe o tamanho do arquivo em MB: ");
                fileSize = int.Parse(Console.ReadLine());

                while (fileSize <= 0)
                {
                    Console.WriteLine("O tamanho do arquivo deve ser positivo!");
                    Console.Write("Informe o tamanho do arquivo em MB: ");
                    fileSize = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("Você deseja alterar o tamanho máximo do buffer (1MB): s ou n");
            string changeBufferSize = Console.ReadLine();

            int bufferSize = 1;

            if (changeBufferSize == "s")
            {
                Console.Write("Informe o tamanho máximo do buffer em MB: ");
                bufferSize = int.Parse(Console.ReadLine());

                while (bufferSize <= 0)
                {
                    Console.WriteLine("O tamanho máximo do buffer deve ser positivo!");
                    Console.Write("Informe o tamanho máximo do buffer em MB: ");
                    bufferSize = int.Parse(Console.ReadLine());
                }
            }

            using (WebCrawler webCrawler = new WebCrawler())
            {
                using (FileGenerator fileGenerator = new FileGenerator(webCrawler))
                {
                    fileGenerator.GenerateFile(path, fileSize, bufferSize);
                }
            }

            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadLine();
        }
    }
}
