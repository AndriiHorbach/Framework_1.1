namespace Framework.Tests
{
    using Controls;
    using Data;
    using SeleniumDriver;
    using Pages;
    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;
    using NUnit.Framework;
    using OpenQA.Selenium.Support.UI;
    using OpenQA.Selenium;

    [Binding]
    class PersonaCabinetSteps
    {
        private readonly PersonalCabinetPage Page = new PersonalCabinetPage(SeleniumDriver.getDriver());
        private HtmlInput Input = new HtmlInput();
        private HtmlButton Button = new HtmlButton(SeleniumDriver.getDriver());
        private HtmlLink Link = new HtmlLink();

        [Given(@"I am logged in as user in personal cabinet")]
        public void GivenIAmLoggedInAsUserInPersonalCabinet(Table table)
        {
            SeleniumDriver.getDriver().Navigate().GoToUrl(Page.URL);

            var userData = table.CreateInstance<UserData>();
            Input.SendKeys(Page.LoginField, userData.Login);
            Input.SendKeys(Page.PasswordField, userData.Password);
            Button.Click(Page.LoginButton);
        }


        [When(@"I select wishlist")]
        public void WhenISelectWishlist()
        {
            Page.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[@class='profile-m-i'][3]/a")));
            Link.Click(Page.WishlistLink);
        }

        [Then(@"wishlist is empty")]
        public void ThenWishlistIsEmpty()
        {
            Assert.IsTrue(Page.EmptyWishlistHeader.Text.Equals(Page.EmptyWishlistText));
        }

        [Then(@"I can create new wishlist")]
        public void ThenICanCreateNewWishlist()
        {
            Assert.IsTrue(Page.FirstWishListButton.Displayed);
        }


    }
}
