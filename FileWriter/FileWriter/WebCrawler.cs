using OpenQA.Selenium.Chrome;
using System;

namespace FileWriter
{
    public static class WebCrawler
    {
        private static readonly ChromeDriver _webDriver;

        static WebCrawler()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("headless");
            _webDriver = new ChromeDriver(options);
        }

        private static string[] _sentences = new string[]
        {
            "No mundo atual, o surgimento do comércio virtual promove a alavancagem dos métodos utilizados na avaliação de resultados.",
            "Percebemos, cada vez mais, que a adoção de políticas descentralizadoras estimula a padronização do fluxo de informações.",
            "Neste sentido, o comprometimento entre as equipes obstaculiza a apreciação da importância do fluxo de informações."
        };

        private static Random _random = new Random();

        private static int _randomNumber = 0;

        public static string GetSentence()
        {
            try
            {
                _webDriver.Navigate().GoToUrl("https://lerolero.com/");
                return _webDriver.FindElementByClassName("sentence").Text;
            }
            catch
            {
                _randomNumber = _random.Next(_sentences.Length);
                return _sentences[_randomNumber];
            }
        }
    }
}
