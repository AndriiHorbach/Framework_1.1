using Framework.Infrastructure.Common;
using Framework.Infrastructure.Pages.Page_Factory;

namespace Framework.Tests.Steps
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System.Linq;
    using TechTalk.SpecFlow;
    using NUnit.Framework;
    using Infrastructure.Pages;

    [Binding]
    class RozetkaSteps
    {
        private readonly MainPage _rozetkaPage = PageFactory.GetPage<MainPage>();

        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
            => SeleniumDriver.GetDriver().Navigate().GoToUrl(_rozetkaPage.Url);   

        [When(@"I search for (\S+)")]
        public void WhenISearchFor(string text)
        {
            _rozetkaPage.SearchField.SetText(text);
            _rozetkaPage.SearchField.Submit();
        }

        [When(@"I filter by (\S+) for (\S+)")]
        public void WhenISelectCharacteristicInFilterSection(string filterSection,  string checkboxInSection)
        {
            _rozetkaPage.WaitForPageLoad();
            ((_rozetkaPage.Filters.ItemsForSection(filterSection)).First(i => i.Text.Contains(checkboxInSection))).Click();
            _rozetkaPage.WaitForPageLoad();
            //_rozetkaPage.Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy((By.XPath("//div[@tool_tip]/a/img"))));
        }

       [When(@"I proceed to checkout with (.*) name, (.*) mobile, (.*) e-mail")]
        public void WhenIProccedToCheckoutWith(string receiverName, string receiverMobile, string receiverEmail)
        {
            _rozetkaPage.Wait.Until(condition => _rozetkaPage.IsElementDisplayed(_rozetkaPage.BuyButtons));
            _rozetkaPage.BuyButtons.Click();
            _rozetkaPage.Wait.Until(condition => _rozetkaPage.IsElementDisplayed(_rozetkaPage.CheckoutButton));
            _rozetkaPage.CheckoutButton.Click();
            //_rozetkaPage.Wait.Until(condition => _rozetkaPage.ReceiverName.Displayed);
            _rozetkaPage.ReceiverName.SetText(receiverName);
            _rozetkaPage.ReceiverPhone.SetText(receiverMobile);
            _rozetkaPage.ReceiverEmail.SetText(receiverEmail);
        }


        [When (@"I go next")]
        public void GoNext()
        {
            _rozetkaPage.Wait.Until(condition => _rozetkaPage.IsElementDisplayed(_rozetkaPage.NextButton));
            _rozetkaPage.NextButton.Click();
        }

        [Then(@"I cannot confirm order")]
        public void ThenICannotConfirmOrderButton()
            => Assert.IsFalse(_rozetkaPage.ConfirmOrderButton.Displayed, "Confirm order button is not displayed");

       [Then(@"I can confirm order")]
       public void ThenICanConfirmOrder()
       {
            _rozetkaPage.Wait.Until(condition => _rozetkaPage.IsElementDisplayed(_rozetkaPage.NextButton));
            _rozetkaPage.NextButton.Click();
            Assert.IsTrue(_rozetkaPage.ConfirmOrderButton.Displayed, "Confirm order button is not displayed");
       }
    }
}
