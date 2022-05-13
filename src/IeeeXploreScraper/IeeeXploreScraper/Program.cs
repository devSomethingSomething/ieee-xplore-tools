using OpenQA.Selenium;
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

            // Read links from file and modify them
            // Go to each link in file
            // Store value in file
            // Go to next page

            GoToUrl("https://ieeexplore.ieee.org/document/743356/");

            int fullTextViews = GetElementValue();

            Console.WriteLine(fullTextViews);

            CloseDriver();

            Console.ReadKey(true);
        }

        private static int GetElementValue()
        {
            return Convert.ToInt32(chromeDriver.FindElement(By.CssSelector("#LayoutWrapper > div > div > div > div.ng2-app > div > xpl-root > div > xpl-document-details > div > div.document-main.global-content-width-w-rr > section.document-main-header.row > div > xpl-document-header > section > div.document-header-inner-container.row > div > div > div.document-main-subheader > div.document-header-metrics-banner.row > div.document-banner.col.stats-document-banner > div.document-banner-metric-container.row > button:nth-child(2) > div.document-banner-metric-count")).Text);
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
