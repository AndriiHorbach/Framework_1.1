namespace Framework.Hooks
{
    using OpenQA.Selenium;
    using TechTalk.SpecFlow;
    using SeleniumDriver;

    [Binding]
    public static class Hooks
    {
        public static IWebDriver Driver;

        //[BeforeFeature]
        [BeforeScenario]
        public static void InitDriver()
        {
            Driver = SeleniumDriver.getDriver();            
            Driver.Manage().Window.Maximize();
        }

        //[AfterFeature]
        [AfterScenario]
        public static void DisposeDriver() 
            => Driver.Dispose();
    }
}
