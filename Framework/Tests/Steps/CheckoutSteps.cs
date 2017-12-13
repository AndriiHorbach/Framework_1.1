namespace Framework 
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using RozetkaPages;
    using SeleniumDriver;
    using Controls;
    using System.Linq;
    using TechTalk.SpecFlow;
    using NUnit.Framework;
    using System.Threading;

    [Binding]
    class RozetkaSteps
    {
        private readonly RozetkaPage Page = new RozetkaPage(SeleniumDriver.SeleniumDriver.getDriver());
        private HtmlInput Input = new HtmlInput();
        private HtmlButton Button = new HtmlButton(SeleniumDriver.SeleniumDriver.getDriver());

        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
            => SeleniumDriver.SeleniumDriver.getDriver().Navigate().GoToUrl(Page.URL);   

        [When(@"I search for (\S+)")]
        public void WhenISearchFor(string text)
        {
            Input.SendKeys(Page.SearchField, text);
            Input.Submit(Page.SearchField);
        }

        [When(@"I filter by (\S+) for (\S+)")]
        public void WhenISelectCharacteristicInFilterSection(string filterSection,  string checkboxInSection)
        {
            Page.Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@class='filter-parametrs-i']")));
            ((Page.Filters.ItemsForSection(filterSection)).First(i => i.Text.Contains(checkboxInSection))).Click();
            Page.Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy((By.XPath("//div[@tool_tip]/a/img"))));
        }

       [When(@"I proceed to checkout with (.*) name, (.*) mobile, (.*) e-mail")]
        public void WhenIProccedToCheckoutWith(string ReceiverName, string ReceiverMobile, string ReceiverEmail)
        {
            Page.Wait.Until(ExpectedConditions.ElementIsVisible(By.Name("topurchasesfromcatalog")));
            Button.Click(Page.BuyButtons.First());
            Page.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cart-popup")));
            Button.Click(Page.CheckoutButton);
            Page.Wait.Until(ExpectedConditions.ElementExists(By.Id("reciever_name")));
            Input.SendKeys(Page.ReceiverName, ReceiverName);
            Input.SendKeys(Page.ReceiverPhone, ReceiverMobile);
            Input.SendKeys(Page.ReceiverEmail, ReceiverEmail);
        }

        [Then(@"I cannot confirm order")]
        public void ThenICannotConfirmOrderButton()
        {
            //Page.ClickOn(Page.NextButton);
            Assert.IsFalse(Page.ConfirmOrderButton.Displayed, "Confirm order button is not displayed");
        }

       [Then(@"I can confirm order")]
       public void ThenICanConfirmOrder()
       {
            Page.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@class='btn-link btn-link-green check-step-btn-link opaque']")));
           Button.Click(Page.NextButton);
           Assert.IsTrue(Page.ConfirmOrderButton.Displayed, "Confirm order button is not displayed");
       }
    }
}
