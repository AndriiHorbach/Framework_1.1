namespace Framework.Controls
{
    using Framework.Controls.Interfaces;
    using SeleniumDriver;
    using OpenQA.Selenium;
    
    class HtmlButton : IButton
    {
        protected static IWebDriver Driver = SeleniumDriver.getDriver();
        public HtmlButton (IWebDriver driver)
            => driver = Driver;


        public void Click1()
        { 
            //Driver.Click();
        }

        public void Click(IWebElement el)
            => el.Click();
    }
}
