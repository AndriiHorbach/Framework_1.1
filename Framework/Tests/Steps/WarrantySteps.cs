namespace Framework.Tests.Steps
{
    using Controls;
    using SeleniumDriver;
    using Pages;
    using System.Linq;
    using TechTalk.SpecFlow;
    using System.Collections.Generic;
    using Data;
    using OpenQA.Selenium.Support.UI;
    using OpenQA.Selenium;
    using TechTalk.SpecFlow.Assist;
    using NUnit.Framework;

    [Binding]
    class WarrantySteps
    {
        private HtmlButton Button = new HtmlButton(SeleniumDriver.getDriver());
        private HtmlLink Link = new HtmlLink();
        private readonly ServicePage ServicePage = new ServicePage(SeleniumDriver.getDriver());
        private readonly WarrantyPage WarrantyPage = new WarrantyPage(SeleniumDriver.getDriver());
        private readonly PersonalCabinetPage PersonalCabinetPage = new PersonalCabinetPage(SeleniumDriver.getDriver());

        [Then(@"I see following messages")]
        public void ThenISeeFollowingMessages(Table table)
        {


            var errorMessages = table.CreateSet<ErrorMessages>();
            //table.CompareToSet(errorMessages);
            //<string<ErrorMessages>>()



        }

        [Then(@"Return request form is not submitted")]
        public void ThenReturnRequestFormIsNotSubmitted()
        {
            var a = ServicePage.ReasonOfReturnHelpMessage.Text;
            var b = ServicePage.IssueDetailsDivHelpMessage.Text;


            var c = ServicePage.TypeOfReturnHelpMessage.Text;
            var d = ServicePage.TypeOfDeliveryHelpMessage.Text;





            Assert.IsTrue(ServicePage.ReasonOfReturnHelpMessage.Text.Equals(ServicePage.ReasonOfReturnMessage), "Incorrect Reason of Return error message");
            Assert.IsTrue(ServicePage.IssueDetailsDivHelpMessage.Text.Equals(ServicePage.IssueDetailsMessage), "Incorrect Isuue Details error message");
            Assert.IsTrue(ServicePage.TypeOfReturnHelpMessage.Text.Equals(ServicePage.TypeOfReturnMessage), "Incorrect Type of Return error message");
            Assert.IsTrue(ServicePage.TypeOfDeliveryHelpMessage.Text.Equals(ServicePage.TypeOfDeliveryMessage), "Incorrect Type of Delivery error message");
        }

        [When(@"I submit Return request form without mandatory fields")]
        public void WhenISubmitReturnRequestFormWithoutMandatoryFields()
        {
            Link.Click(PersonalCabinetPage.MenuBar.SelectMenuPoint("Гарантия"));
            Link.Click(WarrantyPage.ServiceLink);
            Link.Click(ServicePage.RequestReturnLinks.First());
            ServicePage.Wait.Until((ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.ClassName("detail-buy-btn-container"))));
            Button.Click(ServicePage.SubmitRequestButtons.First());
            ServicePage.Wait.Until((ExpectedConditions.ElementIsVisible(By.ClassName("field-submit-checked"))));
            Button.Click(ServicePage.SendRequestButton);
        }

    }
}
