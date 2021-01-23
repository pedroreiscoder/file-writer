using System;

namespace FileWriter.Generator
{
    public interface IFileGenerator : IDisposable
    {
        void GenerateFile(string path, int fileSize, int bufferSize);
    }
}
