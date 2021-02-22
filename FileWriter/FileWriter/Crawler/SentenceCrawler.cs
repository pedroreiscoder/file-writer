using OpenQA.Selenium.Chrome;
using System;

namespace FileWriter.Crawler
{
    public class SentenceCrawler : ISentenceCrawler
    {
        private readonly ChromeDriver _webDriver;

        public SentenceCrawler()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("headless");

            _webDriver = new ChromeDriver(service, options);
        }

        private static string[] _sentences = new string[]
        {
            "No mundo atual, o surgimento do comércio virtual promove a alavancagem dos métodos utilizados na avaliação de resultados.",
            "Percebemos, cada vez mais, que a adoção de políticas descentralizadoras estimula a padronização do fluxo de informações.",
            "Neste sentido, o comprometimento entre as equipes obstaculiza a apreciação da importância do fluxo de informações."
        };

        private static Random _random = new Random();

        public string GetSentence()
        {
            try
            {
                _webDriver.Navigate().GoToUrl("https://lerolero.com/");
                return _webDriver.FindElementByClassName("sentence").Text;
            }
            catch
            {
                return _sentences[_random.Next(_sentences.Length)];
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
