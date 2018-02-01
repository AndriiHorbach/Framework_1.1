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

        [Then(@"I see '(.*)' message")]
        public void ThenISeeMessages(string ordersMessage)
        {
            ServicePage.Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.service-orders>p")));
            Assert.IsTrue(ServicePage.ServiceOrdersMessage.GetText.Equals(ordersMessage), "Incorrect Reason of Return error message");
        }

        [When(@"I navigate to Return request")]
        public void WhenISubmitReturnRequestFormWithoutMandatoryFields()
        {
            PersonalCabinetPage.Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("whitelink")));
            PersonalCabinetPage.MenuBar.SelectMenuPoint("Гарантия").Click();
            WarrantyPage.ServiceLink.Click();
        }
    }
}
