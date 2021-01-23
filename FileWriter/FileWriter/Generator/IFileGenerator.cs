using System;

namespace FileWriter.Generator
{
    public interface IFileGenerator : IDisposable
    {
        Report GenerateFile(string path, int fileSize, int bufferSize);
    }
}
