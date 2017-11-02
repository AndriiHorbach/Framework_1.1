namespace Framework.Hooks
{
    using OpenQA.Selenium;
    using TechTalk.SpecFlow;
    using SeleniumDriver;
    //using Framework.Reporting;

    [Binding]
    public static class Hooks
    {
        public static IWebDriver Driver;
        //public static Report report;

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
        //public static void AddToReport()
        //    => report.addLine("sa", "ss", "ww");
    }
}
