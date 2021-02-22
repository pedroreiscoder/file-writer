using System;

namespace FileWriter.Configuration
{
    public static class FileSizeConfiguration
    {
        public static int GetFileSize()
        {
            int fileSize = 100;

            Console.WriteLine("Você deseja alterar o tamanho padrão do arquivo (100MB): s ou n");
            string changeFileSize = Console.ReadLine();

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

            return fileSize;
        }
    }
}
