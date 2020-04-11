using Xunit;

namespace GemsSelenium.Tests
{
    public class BrowserOpsTests
    {
        [Theory]
        [InlineData("https://gemsdev.ru/geometa/", "my-150")]
        [InlineData("https://gemsdev.ru/geometa/", "gos-system")]
        [InlineData("https://gemsdev.ru/geometa/", "urban-analytics")]
        [InlineData("https://gemsdev.ru/geometa/", "other-products")]
        public void FindElement_ElementIsVisible(string url, string className)
        {
            BrowserOps pik = new BrowserOps(url);

            bool actual = pik.FindVisibleElement(className);

            Assert.True(actual);
        }

        [Fact]
        public void FindElement_LinkToGysSystem()
        {
            BrowserOps pik = new BrowserOps("https://gemsdev.ru/geometa/");

            bool actual = pik.FindLink("https://xn--c1aaceme9acfqh.xn--p1ai/");

            Assert.True(actual);
        }
    }
}
