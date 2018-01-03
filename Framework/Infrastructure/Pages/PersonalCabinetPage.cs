namespace Framework.Infrastructure.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using SeleniumDriver;

    class PersonalCabinetPage : BasePage
    {
        public string URL = "https://my.rozetka.com.ua";
        public string EmptyWishlistText = "Ваш список желаний пока пуст";


        [FindsBy(How = How.Name, Using = "login")]
        public IWebElement LoginField;

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement PasswordField;

        [FindsBy(How = How.XPath, Using = "//div[@class='signup-submit']/button/span")]
        public IWebElement LoginButton;

        [FindsBy(How = How.XPath, Using = "//li[@class='profile-m-i'][3]/a")]
        public IWebElement WishlistLink;

        [FindsBy(How = How.XPath, Using = "//h3[@class='wishlist-i-empty-title']")]
        public IWebElement EmptyWishlistHeader;

        [FindsBy(How = How.Id, Using = "firstlist_button")]
        public IWebElement FirstWishListButton;

        public MenuBar MenuBar
          => new MenuBar(SeleniumDriver.GetDriver().FindElement(By.ClassName("flex")));
    }
}
