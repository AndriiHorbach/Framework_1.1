using Framework.Infrastructure.Pages.Page_Factory;

namespace Framework.Tests.Steps
{
    using TechTalk.SpecFlow;
    using NUnit.Framework;
    using Infrastructure.Pages;

    [Binding]
    class WarrantySteps
    {
        private readonly PersonalCabinetPage _personalCabinetPage = PageFactory.GetPage<PersonalCabinetPage>();
        private readonly ServicePage _servicePage = PageFactory.GetPage<ServicePage>();
        private readonly WarrantyPage _warrantyPage = PageFactory.GetPage<WarrantyPage>();

        [Then(@"I see '(.*)' message")]
        public void ThenISeeMessages(string ordersMessage)
        {
            _personalCabinetPage.Wait.Until(condition => _servicePage.IsElementDisplayed(_servicePage.ServiceOrdersMessage));
            Assert.IsTrue(_servicePage.ServiceOrdersMessage.GetText.Equals(ordersMessage), "Incorrect Reason of Return error message");
        }

        [When(@"I navigate to Return request")]
        public void WhenISubmitReturnRequestFormWithoutMandatoryFields()
        {
            _personalCabinetPage.WaitForPageLoad();
            _personalCabinetPage.MenuBar.SelectMenuPoint("Гарантия").Click();
            _warrantyPage.ServiceLink.Click();
        }
    }
}
