using System;

namespace FileWriter.Crawler
{
    public interface IWebCrawler : IDisposable
    {
        string GetSentence();
        int GetBytes(string sentence);
    }
}
