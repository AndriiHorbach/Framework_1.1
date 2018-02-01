using Framework.Infrastructure.Common;

namespace Framework.Infrastructure.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System;

    public  class BasePage
    {
        public WebDriverWait Wait = new WebDriverWait(SeleniumDriver.GetDriver(), TimeSpan.FromSeconds(10));

        public void WaitForPageLoad()
            => Wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
    }
}
