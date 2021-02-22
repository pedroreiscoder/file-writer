using System;

namespace FileWriter.Crawler
{
    public interface IBytesCrawler : IDisposable
    {
        int GetBytes(string sentence);
    }
}
