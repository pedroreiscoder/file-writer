using System;
using System.Text;

namespace FileWriter.Generator
{
    public class Report
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public string Path { get; set; }
        public int Iterations { get; set; }
        public TimeSpan TotalTime { get; set; }
        public TimeSpan AverageTime { get; set; }

        public override string ToString()
        {
            StringBuilder reportBuilder = new StringBuilder();

            reportBuilder.AppendLine($"Nome: {Name}");
            reportBuilder.AppendLine($"Tamanho: {Size}mb");
            reportBuilder.AppendLine($"Path: {Path}");
            reportBuilder.AppendLine($"Iterações: {Iterations}");
            reportBuilder.AppendLine($"Tempo Total: {TotalTime}");
            reportBuilder.AppendLine($"Tempo Médio: {AverageTime}");

            return reportBuilder.ToString();
        }
    }
}
