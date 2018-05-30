using Framework.Infrastructure.Common;
using Framework.Infrastructure.Controls.Elements;
using Framework.Infrastructure.Pages.Panels;

namespace Framework.Infrastructure.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    class MainPage : BasePage
    {
        public readonly string Url = "http://rozetka.com.ua/";

        [FindsBy(How = How.Name, Using = "text")]
        public Input SearchField;

        [FindsBy(How = How.Name, Using = "topurchasesfromcatalog")]
        public Button BuyButtons;

        [FindsBy(How = How.XPath, Using = "//div[@id='cart-popup']//button[@id='popup-checkout']")]
        public Button CheckoutButton;

        [FindsBy(How = How.Id, Using = "reciever_name")]
        public Input ReceiverName;

        [FindsBy(How = How.Id, Using = "reciever_phone")]
        public Input ReceiverPhone;

        [FindsBy(How = How.Id, Using = "reciever_email")]
        public Input ReceiverEmail;

        [FindsBy(How = How.XPath, Using = "//span[@class='btn-link btn-link-green check-step-btn-link opaque']/button")]
        public Button NextButton;

        [FindsBy(How = How.Id, Using = "make-order")]
        public Button ConfirmOrderButton;            

        public FiltersForm Filters
            => new FiltersForm(SeleniumDriver.GetDriver().FindElement(By.Id("parameters-filter-form")));
    }
}