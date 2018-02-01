namespace Framework.Infrastructure.Pages
{
    using global::Framework.Infrastructure.Controls;
    using OpenQA.Selenium.Support.PageObjects;

    class WarrantyPage : BasePage
    {
        public readonly string URL = "https://rozetka.com.ua/warranty/";

        [FindsBy(How = How.XPath, Using = "//div[@class='text-page']/section[3]/p[4]/a")]
        public Link ServiceLink;            
    }
}

