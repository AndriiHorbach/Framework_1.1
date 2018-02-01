using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Framework.Infrastructure.Common
{
    [Binding]
    public static class Hooks
    {
        private static IWebDriver _driver;

        //[BeforeFeature]
        [BeforeScenario]
        public static void InitDriver()
        {
            _driver = SeleniumDriver.GetDriver();            
            _driver.Manage().Window.Maximize();
        }

        //[AfterFeature]
        [AfterScenario]
        public static void DisposeDriver() 
            => _driver.Dispose();
    }
}
