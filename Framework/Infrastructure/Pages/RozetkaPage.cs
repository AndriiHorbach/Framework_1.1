namespace Framework.Infrastructure.Pages
{
    using System.Collections.Generic;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using SeleniumDriver;

    public class RozetkaPage : BasePage
    {
        public string URL = "http://rozetka.com.ua/";

        [FindsBy(How = How.Name, Using = "text")]
        public IWebElement SearchField;

        [FindsBy(How = How.Name, Using = "topurchasesfromcatalog")]
        public IList<IWebElement> BuyButtons;

        [FindsBy(How = How.Id, Using = "popup-checkout")]
        public IWebElement CheckoutButton;

        [FindsBy(How = How.Id, Using = "reciever_name")]
        public IWebElement ReceiverName;

        [FindsBy(How = How.Id, Using = "reciever_phone")]
        public IWebElement ReceiverPhone;

        [FindsBy(How = How.Id, Using = "reciever_email")]
        public IWebElement ReceiverEmail;

        [FindsBy(How = How.XPath, Using = "//button[@tabindex='6']")]
        public IWebElement NextButton;

        [FindsBy(How = How.Id, Using = "make-order")]
        public IWebElement ConfirmOrderButton;            

        public FiltersForm Filters
            => new FiltersForm(SeleniumDriver.GetDriver().FindElement(By.Id("parameters-filter-form")));
    }
}