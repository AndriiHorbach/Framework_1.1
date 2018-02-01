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
            _rozetkaPage.Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@class='filter-parametrs-i']")));
            ((_rozetkaPage.Filters.ItemsForSection(filterSection)).First(i => i.Text.Contains(checkboxInSection))).Click();
            _rozetkaPage.Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy((By.XPath("//div[@tool_tip]/a/img"))));
        }

       [When(@"I proceed to checkout with (.*) name, (.*) mobile, (.*) e-mail")]
        public void WhenIProccedToCheckoutWith(string receiverName, string receiverMobile, string receiverEmail)
        {
            _rozetkaPage.Wait.Until(ExpectedConditions.ElementIsVisible(By.Name("topurchasesfromcatalog")));
            _rozetkaPage.BuyButtons.Click();
            _rozetkaPage.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cart-popup")));
            _rozetkaPage.CheckoutButton.Click();
            _rozetkaPage.Wait.Until(ExpectedConditions.ElementExists(By.Id("reciever_name")));
            _rozetkaPage.ReceiverName.SetText(receiverName);
            _rozetkaPage.ReceiverPhone.SetText(receiverMobile);
            _rozetkaPage.ReceiverEmail.SetText(receiverEmail);
        }

        [Then(@"I cannot confirm order")]
        public void ThenICannotConfirmOrderButton()
            => Assert.IsFalse(_rozetkaPage.ConfirmOrderButton.Displayed, "Confirm order button is not displayed");

       [Then(@"I can confirm order")]
       public void ThenICanConfirmOrder()
       {
            _rozetkaPage.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@class='btn-link btn-link-green check-step-btn-link opaque']")));
            _rozetkaPage.NextButton.Click();
            Assert.IsTrue(_rozetkaPage.ConfirmOrderButton.Displayed, "Confirm order button is not displayed");
       }
    }
}
