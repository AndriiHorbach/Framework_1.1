namespace Framework.Infrastructure.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    class WarrantyPage : BasePage
    {
        public string URL = "https://rozetka.com.ua/warranty/";

        [FindsBy(How = How.XPath, Using = "//div[@class='text-page']/section[3]/p[4]/a")]
        public IWebElement ServiceLink;            
    }
}

