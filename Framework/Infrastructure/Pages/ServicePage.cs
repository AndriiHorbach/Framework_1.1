using Framework.Infrastructure.Controls.Elements;

namespace Framework.Infrastructure.Pages
{
    using OpenQA.Selenium.Support.PageObjects;

    class ServicePage : BasePage
    {
        public readonly string Url = "http://service.rozetka.com.ua/";

        [FindsBy(How = How.CssSelector, Using = "div.service-orders>p")]
        public Form ServiceOrdersMessage;       
    }
}