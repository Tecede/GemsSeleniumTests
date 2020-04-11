using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;

namespace GemsSelenium
{
    // TODO: придумать имя класса
    public class BrowserOps
    {
        IWebDriver browser;
        IJavaScriptExecutor js;

        public BrowserOps(string url)
        {
            browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            js = browser as IJavaScriptExecutor;

            browser.Navigate().GoToUrl(url);
        }

        public void Close()
        {
            browser.Close();
        }

        public bool FindElement(string className)
        {
            for (int i = 0; i < 10; i++) // Прокрутка в конец страницы для появления элементов с параметром "Fade*"
            {
                js.ExecuteScript("window.scrollBy(0,500)");
                Thread.Sleep(50);
            }

            IWebElement search = browser.FindElement(By.ClassName(className));

            Console.WriteLine(search.GetCssValue("visibility").ToString());

            return search.GetCssValue("visibility") == "visible" ? true : false;
        }

        public bool FindLink(string link)
        {
            for (int i = 0; i < 10; i++)
            {
                js.ExecuteScript("window.scrollBy(0,500)");
                Thread.Sleep(50);
            }

            try
            {
                IWebElement search = browser.FindElement(By.XPath($"//a[@href='{link}']"));
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
