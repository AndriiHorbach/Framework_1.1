namespace Framework.Hooks
{
    using OpenQA.Selenium;
    using TechTalk.SpecFlow;
    using SeleniumDriver;

    [Binding]
    public static class Hooks
    {
        private static IWebDriver Driver;

        //[BeforeFeature]
        [BeforeScenario]
        public static void InitDriver()
        {
            Driver = SeleniumDriver.GetDriver();            
            Driver.Manage().Window.Maximize();
        }

        //[AfterFeature]
        [AfterScenario]
        public static void DisposeDriver() 
            => Driver.Dispose();
    }
}
