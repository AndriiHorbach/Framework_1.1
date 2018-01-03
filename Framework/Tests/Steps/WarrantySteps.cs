namespace Framework.Tests.Steps
{
    using System.Linq;
    using TechTalk.SpecFlow;
    using OpenQA.Selenium.Support.UI;
    using OpenQA.Selenium;
    using NUnit.Framework;
    using Infrastructure.Pages;

    [Binding]
    class WarrantySteps
    {
        private readonly PersonalCabinetPage PersonalCabinetPage = PageFactory.GetPage<PersonalCabinetPage>();
        private readonly ServicePage ServicePage = PageFactory.GetPage<ServicePage>();
        private readonly WarrantyPage WarrantyPage = PageFactory.GetPage<WarrantyPage>();

        [Then(@"I see '(.*)', '(.*)', '(.*)', '(.*)' messages")]
        public void ThenISeeMessages(string reasonOfReturnMessage, string issueDetailsMessage, string typeOfReturnMessage, string typeOfDeliveryMessage)
        {
            ServicePage.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//div[@id='scgoodsreturnmodel-reason']/following-sibling::div")));
            Assert.IsTrue(ServicePage.ReasonOfReturnHelpMessage.Text.Equals(reasonOfReturnMessage), "Incorrect Reason of Return error message");
            Assert.IsTrue(ServicePage.IssueDetailsDivHelpMessage.Text.Equals(issueDetailsMessage), "Incorrect Isuue Details error message");
            Assert.IsTrue(ServicePage.TypeOfReturnHelpMessage.Text.Equals(typeOfReturnMessage), "Incorrect Type of Return error message");
            Assert.IsTrue(ServicePage.TypeOfDeliveryHelpMessage.Text.Equals(typeOfDeliveryMessage), "Incorrect Type of Delivery error message");
        }

        [When(@"I submit Return request form without mandatory fields")]
        public void WhenISubmitReturnRequestFormWithoutMandatoryFields()
        {
            PersonalCabinetPage.Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("whitelink")));
            PersonalCabinetPage.MenuBar.SelectMenuPoint("Гарантия").Click();
            WarrantyPage.ServiceLink.Click();
            ServicePage.RequestReturnLinks.First().Click();      
            ServicePage.Wait.Until((ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.ClassName("detail-buy-btn-container"))));
            ServicePage.SubmitRequestButtons.First().Click();
            ServicePage.Wait.Until((ExpectedConditions.ElementIsVisible(By.ClassName("field-submit-checked"))));
            ServicePage.SendRequestButton.Click();
        }
    }
}
