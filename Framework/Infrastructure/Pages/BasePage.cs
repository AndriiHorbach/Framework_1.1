namespace Framework.Pages
{

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System;
    using SeleniumDriver;

    public  class BasePage
    {

        protected static IWebDriver Driver = SeleniumDriver.getDriver();
        public BasePage(IWebDriver driver)
            => driver = Driver;

        public WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

        public  void WaitForPageLoad()
            => Wait.Until(Driver => ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").Equals("complete"));

        //public Object evaluateJavascript(final String script)
        //{
        //    return ((JavascriptExecutor)driver).executeScript(script);
        //}


        //public void scrollBottom()
        //{
        //    evaluateJavascript("window.scrollBy(0, document.documentElement.scrollHeight)");
        //}
    }
}
