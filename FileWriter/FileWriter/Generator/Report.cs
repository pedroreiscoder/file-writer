using System;

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
    }
}
