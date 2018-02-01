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
        private readonly MainPage RozetkaPage = PageFactory.GetPage<MainPage>();

        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
            => SeleniumDriver.SeleniumDriver.GetDriver().Navigate().GoToUrl(RozetkaPage.URL);   

        [When(@"I search for (\S+)")]
        public void WhenISearchFor(string text)
        {
            RozetkaPage.SearchField.SetText(text);
            RozetkaPage.SearchField.Submit();
        }

        [When(@"I filter by (\S+) for (\S+)")]
        public void WhenISelectCharacteristicInFilterSection(string filterSection,  string checkboxInSection)
        {
            RozetkaPage.Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@class='filter-parametrs-i']")));
            ((RozetkaPage.Filters.ItemsForSection(filterSection)).First(i => i.Text.Contains(checkboxInSection))).Click();
            RozetkaPage.Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy((By.XPath("//div[@tool_tip]/a/img"))));
        }

       [When(@"I proceed to checkout with (.*) name, (.*) mobile, (.*) e-mail")]
        public void WhenIProccedToCheckoutWith(string ReceiverName, string ReceiverMobile, string ReceiverEmail)
        {
            RozetkaPage.Wait.Until(ExpectedConditions.ElementIsVisible(By.Name("topurchasesfromcatalog")));
            RozetkaPage.BuyButtons.Click();
            RozetkaPage.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cart-popup")));
            RozetkaPage.CheckoutButton.Click();
            RozetkaPage.Wait.Until(ExpectedConditions.ElementExists(By.Id("reciever_name")));
            RozetkaPage.ReceiverName.SetText(ReceiverName);
            RozetkaPage.ReceiverPhone.SetText(ReceiverMobile);
            RozetkaPage.ReceiverEmail.SetText(ReceiverEmail);
        }

        [Then(@"I cannot confirm order")]
        public void ThenICannotConfirmOrderButton()
            => Assert.IsFalse(RozetkaPage.ConfirmOrderButton.Displayed, "Confirm order button is not displayed");

       [Then(@"I can confirm order")]
       public void ThenICanConfirmOrder()
       {
            RozetkaPage.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@class='btn-link btn-link-green check-step-btn-link opaque']")));
            RozetkaPage.NextButton.Click();
            Assert.IsTrue(RozetkaPage.ConfirmOrderButton.Displayed, "Confirm order button is not displayed");
       }
    }
}
