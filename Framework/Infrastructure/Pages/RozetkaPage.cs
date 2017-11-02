namespace Framework.RozetkaPages
{
    using System.Collections.Generic;
    using OpenQA.Selenium;
    using global::Framework.Pages;
    using global::Framework.SharedSteps;

    public class RozetkaPage : BasePage
    {
        public RozetkaPage(IWebDriver driver) : base(driver) { }

        public string URL = "http://rozetka.com.ua/";

        public IWebElement SearchField
            => Driver.FindElement(By.Name("text"));

        public IEnumerable<IWebElement> BuyButtons
            => Driver.FindElements(By.Name("topurchasesfromcatalog"));

        public IWebElement CheckoutButton
            => Driver.FindElement(By.Id("popup-checkout"));

        public IWebElement ReceiverName
            => Driver.FindElement(By.Id("reciever_name"));

        public IWebElement ReceiverPhone
            => Driver.FindElement(By.Id("reciever_phone"));

        public IWebElement ReceiverEmail
            => Driver.FindElement(By.Id("reciever_email"));

        public IWebElement NextButton
            => Driver.FindElement(By.XPath("//button[@tabindex='6']"));

        public IWebElement ConfirmOrderButton
            => Driver.FindElement(By.Id("make-order"));

        public FiltersForm Filters
            => new FiltersForm(Driver.FindElement(By.Id("parameters-filter-form")));
    }
}