namespace Framework.Tests.Steps
{
    using Models;
    using SeleniumDriver;
    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;
    using NUnit.Framework;
    using OpenQA.Selenium.Support.UI;
    using OpenQA.Selenium;
    using Infrastructure.Pages;

    [Binding]
    class PersonaCabinetSteps
    {
        private readonly PersonalCabinetPage PersonalCabinetPage = PageFactory.GetPage<PersonalCabinetPage>();

        [Given(@"I am logged in as user in personal cabinet")]
        public void GivenIAmLoggedInAsUserInPersonalCabinet(Table table)
        {
            SeleniumDriver.GetDriver().Navigate().GoToUrl(PersonalCabinetPage.URL);
            var userData = table.CreateInstance<UserData>();
            PersonalCabinetPage.LoginField.SendKeys(userData.Login);
            PersonalCabinetPage.PasswordField.SendKeys(userData.Password);
            PersonalCabinetPage.LoginButton.Click();
        }

        [When(@"I select wishlist")]
        public void WhenISelectWishlist()
        {
            PersonalCabinetPage.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[@class='profile-m-i'][3]/a")));
            PersonalCabinetPage.WishlistLink.Click();
        }

        [Then(@"wishlist is empty")]
        public void ThenWishlistIsEmpty()
            => Assert.IsTrue(PersonalCabinetPage.EmptyWishlistHeader.Text.Equals(PersonalCabinetPage.EmptyWishlistText));

        [Then(@"I can create new wishlist")]
        public void ThenICanCreateNewWishlist()
            => Assert.IsTrue(PersonalCabinetPage.FirstWishListButton.Displayed);        
    }
}
