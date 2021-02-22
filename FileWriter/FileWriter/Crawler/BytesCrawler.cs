using OpenQA.Selenium.Chrome;
using System.Text;
using System.Web;

namespace FileWriter.Crawler
{
    public class BytesCrawler : IBytesCrawler
    {
        private readonly ChromeDriver _webDriver;

        public BytesCrawler()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("headless");

            _webDriver = new ChromeDriver(service, options);
        }

        public int GetBytes(string sentence)
        {
            string urlSentence = HttpUtility.UrlEncode(sentence, Encoding.UTF8);

            try
            {
                _webDriver.Navigate().GoToUrl($"https://mothereff.in/byte-counter#{urlSentence}");
                string bytesString = _webDriver.FindElementById("bytes").Text;
                return int.Parse(bytesString.Substring(0, bytesString.IndexOf(" ")));
            }
            catch
            {
                return Encoding.UTF8.GetByteCount(sentence);
            }
        }

        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _webDriver.Dispose();
            }
        }
    }
}
