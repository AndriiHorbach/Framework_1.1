using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Framework.Infrastructure.Common
{
    public class SeleniumDriver
    {
        private static IWebDriver _driver;
        private SeleniumDriver() { }

        public static IWebDriver GetDriver()
            => _driver ?? (_driver = new ChromeDriver());           
    }
}