namespace Framework.Pages
{
    using OpenQA.Selenium;
    using System.Collections.Generic;

    class ServicePage : BasePage
    {
        public ServicePage(IWebDriver driver) : base(driver) { }

        public string URL = "http://service.rozetka.com.ua/";
        public string ReasonOfReturnMessage = "Необходимо заполнить «Причина возврата».";
        public string IssueDetailsMessage = "Необходимо заполнить «Описание неисправности».";
        public string TypeOfReturnMessage = "Необходимо заполнить «Цель возврата».";
        public string TypeOfDeliveryMessage = "Необходимо заполнить «Способ отправки».";

        public IWebElement ReasonOfReturnHelpMessage
            => Driver.FindElement(By.XPath(".//div[@id='scgoodsreturnmodel-reason']/following-sibling::div"));

        public IWebElement IssueDetailsDivHelpMessage
            => Driver.FindElement(By.XPath(".//textarea[@id='scgoodsreturnmodel-message']/following-sibling::div"));

        public IWebElement TypeOfReturnHelpMessage
            => Driver.FindElement(By.XPath(".//div[@id='scgoodsreturnmodel-return_type']/following-sibling::div"));

        public IWebElement TypeOfDeliveryHelpMessage
            => Driver.FindElement(By.XPath(".//*[@class='feedback-suggest-wrap']/following-sibling::div"));

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