using System;

namespace FileWriter.Configuration
{
    public static class PathConfiguration
    {
        public static string GetPath()
        {
            Console.Write("Informe o path de escrita do arquivo: ");
            string path = Console.ReadLine();

            while (string.IsNullOrEmpty(path))
            {
                Console.WriteLine("O path para escrita do arquivo é obrigatório!");
                Console.Write("Informe o path de escrita do arquivo: ");
                path = Console.ReadLine();
            }

            return path;
        }
    }
}
