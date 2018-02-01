using Framework.Infrastructure.Common;
using Framework.Infrastructure.Controls.Elements;
using Framework.Infrastructure.Pages.Panels;

namespace Framework.Infrastructure.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    class PersonalCabinetPage : BasePage
    {
        public readonly string Url = "https://my.rozetka.com.ua";

        [FindsBy(How = How.Name, Using = "login")]
        public Input LoginField;

        [FindsBy(How = How.Name, Using = "password")]
        public Input PasswordField;

        [FindsBy(How = How.XPath, Using = "//div[@class='signup-submit']/button/span")]
        public Button LoginButton;

        [FindsBy(How = How.XPath, Using = "//li[@class='profile-m-i'][3]/a")]
        public Link WishlistLink;

        [FindsBy(How = How.Id, Using = "firstlist_button")]
        public Button FirstWishListButton;

        public MenuBar MenuBar
          => new MenuBar(SeleniumDriver.GetDriver().FindElement(By.ClassName("flex")));
    }
}
