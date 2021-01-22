using System;

namespace FileWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando execução");

            Console.WriteLine("Informe o path do arquivo:");
            string path = Console.ReadLine();

            Console.WriteLine("Você deseja alterar o tamanho padrão do arquivo (100MB): s ou n");
            string changeFileSize = Console.ReadLine();

            int fileSize = 100;

            if (changeFileSize == "s")
            {
                Console.WriteLine("Informe o tamanho do arquivo:");
                fileSize = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Você deseja alterar o tamanho máximo do buffer (1MB): s ou n");
            string changeBufferSize = Console.ReadLine();

            int bufferSize = 1;

            if (changeBufferSize == "s")
            {
                Console.WriteLine("Informe o tamanho máximo do buffer:");
                bufferSize = int.Parse(Console.ReadLine());
            }

            FileGenerator.GenerateFile(path, fileSize, bufferSize);

            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadLine();
        }
    }
}
