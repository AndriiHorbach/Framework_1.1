namespace Framework.Infrastructure.Pages
{
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using OpenQA.Selenium.Support.PageObjects;

    class ServicePage : BasePage
    {
        public string URL = "http://service.rozetka.com.ua/";

        [FindsBy(How = How.XPath, Using = ".//div[@id='scgoodsreturnmodel-reason']/following-sibling::div")]
        public IWebElement ReasonOfReturnHelpMessage;

        [FindsBy(How = How.XPath, Using = ".//textarea[@id='scgoodsreturnmodel-message']/following-sibling::div")]
        public IWebElement IssueDetailsDivHelpMessage;

        [FindsBy(How = How.XPath, Using = ".//div[@id='scgoodsreturnmodel-return_type']/following-sibling::div")]
        public IWebElement TypeOfReturnHelpMessage;

        [FindsBy(How = How.XPath, Using = ".//*[@class='feedback-suggest-wrap']/following-sibling::div")]
        public IWebElement TypeOfDeliveryHelpMessage;

        [FindsBy(How = How.ClassName, Using = "btn-link-i")]
        public IList <IWebElement> RequestReturnLinks;

        [FindsBy(How = How.ClassName, Using = "detail-buy-btn-container")]
        public IList<IWebElement> SubmitRequestButtons;

        [FindsBy(How = How.ClassName, Using = "field-submit-checked")]
        public IWebElement SendRequestButton;
    }
}