namespace Framework.SeleniumDriver
{
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;

    public class SeleniumDriver
    {
        private static IWebDriver Driver;
        private SeleniumDriver() { }

        public static IWebDriver getDriver()
            => Driver ?? (Driver = new ChromeDriver());
           
    }
}