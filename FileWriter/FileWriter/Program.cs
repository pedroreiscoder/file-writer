using System;

namespace FileWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence = WebCrawler.GetSentence();
            Console.WriteLine(sentence);
            Console.WriteLine(WebCrawler.GetBytes(sentence));
            Console.ReadLine();
        }
    }
}
