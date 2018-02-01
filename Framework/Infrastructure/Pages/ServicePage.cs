namespace Framework.Infrastructure.Pages
{
    using OpenQA.Selenium.Support.PageObjects;
    using Framework.Infrastructure.Controls;

    class ServicePage : BasePage
    {
        public readonly string URL = "http://service.rozetka.com.ua/";

        [FindsBy(How = How.CssSelector, Using = "div.service-orders>p")]
        public Form ServiceOrdersMessage;       
    }
}