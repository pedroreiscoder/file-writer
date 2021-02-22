using System;

namespace FileWriter.Configuration
{
    public static class BufferSizeConfiguration
    {
        public static int GetBufferSize()
        {
            int bufferSize = 1;

            Console.WriteLine("Você deseja alterar o tamanho máximo do buffer (1MB): s ou n");
            string changeBufferSize = Console.ReadLine();

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

            return bufferSize;
        }
    }
}
