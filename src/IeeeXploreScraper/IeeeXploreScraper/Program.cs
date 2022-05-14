using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;

namespace IeeeXploreScraper
{
    public class Program
    {
        private static ChromeDriver chromeDriver;

        private static string path;

        private static string[] lines;

        private static void Main()
        {
            GetPath();

            GetLines();

            SetupDriver();

            WriteDataToFile();

            CloseDriver();

            Console.ReadKey(true);
        }

        private static void GetPath()
        {
            Console.Write("Enter a path: ");
            path = Console.ReadLine();
        }

        private static void GetLines()
        {
            lines = File.ReadAllLines(path);
        }

        private static int GetElementValue()
        {
            try
            {
                return Convert.ToInt32(chromeDriver.FindElement(By.CssSelector("#LayoutWrapper > div > div > div > div.ng2-app > div > xpl-root > div > xpl-document-details > div > div.document-main.global-content-width-w-rr > section.document-main-header.row > div > xpl-document-header > section > div.document-header-inner-container.row > div > div > div.document-main-subheader > div.document-header-metrics-banner.row > div.document-banner.col.stats-document-banner > div.document-banner-metric-container.row > button:nth-child(2) > div.document-banner-metric-count")).Text);
            }
            catch (Exception)
            {
                return Convert.ToInt32(chromeDriver.FindElement(By.CssSelector("#LayoutWrapper > div > div > div > div.ng2-app > div > xpl-root > div > xpl-document-details > div > div.document-main.global-content-width-w-rr > section.document-main-header.row > div > xpl-document-header > section > div.document-header-inner-container.row > div > div > div.document-main-subheader > div.document-header-metrics-banner.row > div.document-banner.col.stats-document-banner > div.document-banner-metric-container.row > button > div.document-banner-metric-count")).Text);
            }
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

        private static void WriteDataToFile()
        {
            using StreamWriter streamWriter = new StreamWriter("results.txt", false);

            foreach (var line in lines)
            {
                string url = "https://ieeexplore.ieee.org/document/" + line.Substring(line.IndexOf('=') + 1) + "/";

                GoToUrl(url);

                int fullTextViews = GetElementValue();

                streamWriter.WriteLine(fullTextViews);
            }
        }
    }
}
