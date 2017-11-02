namespace Framework.Pages
{
    using OpenQA.Selenium;
    using System.Collections.Generic;

    class ServicePage : BasePage
    {
        public ServicePage(IWebDriver driver) : base(driver) { }

        public string URL = "http://service.rozetka.com.ua/";
        public string ReasonOfReturnMessage = "Причина возврата cannot be blank.";
        public string IssueDetailsMessage = "Описание неисправности cannot be blank.";
        public string TypeOfReturnMessage = "Цель возврата cannot be blank.";
        public string TypeOfDeliveryMessage = "Способ отправки cannot be blank.";

        public IWebElement ReasonOfReturnHelpMessage
            => Driver.FindElement(By.XPath(".//div[@id='scgoodsreturnmodel-reason']/following-sibling::div"));

        public IWebElement IssueDetailsDivHelpMessage
            => Driver.FindElement(By.XPath(".//textarea[@id='scgoodsreturnmodel-message']/following-sibling::div"));

        public IWebElement TypeOfReturnHelpMessage
            => Driver.FindElement(By.XPath(".//div[@id='scgoodsreturnmodel-return_type']/following-sibling::div"));

        public IWebElement TypeOfDeliveryHelpMessage
            => Driver.FindElement(By.XPath(".//select[@id='scgoodsreturnmodel-delivery_id']/following-sibling::div"));

        public IEnumerable <IWebElement> RequestReturnLinks
            => Driver.FindElements(By.ClassName("btn-link-i"));

        public IEnumerable<IWebElement> SubmitRequestButtons
            => Driver.FindElements(By.ClassName("detail-buy-btn-container"));

        //public IEnumerable<IWebElement> HelpBlocks
        //   => Driver.FindElements(By.ClassName("help-block"));

        public IWebElement SendRequestButton
            => Driver.FindElement(By.ClassName("field-submit-checked"));
    }
}