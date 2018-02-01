using Framework.Infrastructure.Controls.Elements;

namespace Framework.Infrastructure.Pages
{
    using OpenQA.Selenium.Support.PageObjects;

    class WarrantyPage : BasePage
    {
        public readonly string Url = "https://rozetka.com.ua/warranty/";

        [FindsBy(How = How.XPath, Using = "//div[@class='text-page']/section[3]/p[4]/a")]
        public Link ServiceLink;            
    }
}

