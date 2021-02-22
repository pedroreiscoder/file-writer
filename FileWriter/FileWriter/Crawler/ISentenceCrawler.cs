using System;

namespace FileWriter.Crawler
{
    public interface ISentenceCrawler : IDisposable
    {
        string GetSentence();
    }
}
