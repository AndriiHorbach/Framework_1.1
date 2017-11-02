namespace Framework.Pages 
{
    using OpenQA.Selenium;

    class WarrantyPage : BasePage
    {
        public WarrantyPage(IWebDriver driver) : base(driver) { }

        public string URL = "https://rozetka.com.ua/warranty/";
        
        public IWebElement ServiceLink
            => Driver.FindElement(By.XPath("//div[@class='text-page']/section[3]/p[4]/a"));
    }
}

