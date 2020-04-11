using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using System.Threading;

namespace GemsSelenium
{
    public class BrowserOps
    {
        PhantomJSDriver browser;

        public BrowserOps(string url)
        {
            browser = new PhantomJSDriver();

            browser.Navigate().GoToUrl(url);
        }

        public bool FindVisibleElement(string className)
        {
            IWebElement search = browser.FindElement(By.ClassName(className));

            return search.GetCssValue("visibility") == "visible" ? true : false;
        }

        public bool FindLink(string link)
        {
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
