using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace IeeeXploreScraper
{
    public class Program
    {
        private static ChromeDriver chromeDriver;

        private static void Main()
        {
            SetupDriver();

            GoToUrl("https://www.google.com/");

            CloseDriver();

            Console.ReadKey(true);
        }

        private static void SetupDriver()
        {
            chromeDriver = new ChromeDriver();
        }

        private static void CloseDriver()
        {
            chromeDriver.Quit();
        }

        private static void GoToUrl(string url, int sleepTime = 3000)
        {
            chromeDriver.Url = url;

            Thread.Sleep(sleepTime);
        }
    }
}
