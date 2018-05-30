using Framework.Infrastructure.Common;
using Framework.Infrastructure.Models;
using Framework.Infrastructure.Pages.Page_Factory;

namespace Framework.Tests.Steps
{
    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;
    using NUnit.Framework;
    using Infrastructure.Pages;

    [Binding]
    class PersonaCabinetSteps
    {
        private readonly PersonalCabinetPage _personalCabinetPage = PageFactory.GetPage<PersonalCabinetPage>();

        [Given(@"I am logged in as user in personal cabinet")]
        public void GivenIAmLoggedInAsUserInPersonalCabinet(Table table)
        {
            SeleniumDriver.GetDriver().Navigate().GoToUrl(_personalCabinetPage.Url);
            var userData = table.CreateInstance<UserData>();
            _personalCabinetPage.LoginField.SetText(userData.Login);
            _personalCabinetPage.PasswordField.SetText(userData.Password);
            _personalCabinetPage.LoginButton.Click();
        }

        [When(@"I select wishlist")]
        public void WhenISelectWishlist()
        {
            _personalCabinetPage.Wait.Until(condition => _personalCabinetPage.IsElementDisplayed(_personalCabinetPage.WishlistLink));
            _personalCabinetPage.WishlistLink.Click();
        }

        [Then(@"I can create new wishlist")]
        public void ThenICanCreateNewWishlist()
            => Assert.IsTrue(_personalCabinetPage.FirstWishListButton.Displayed);        
    }
}
