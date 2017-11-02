namespace Framework.Pages
{
    using OpenQA.Selenium;

    class PersonalCabinetPage : BasePage
    {
        public string URL = "https://my.rozetka.com.ua";
        public string EmptyWishlistText = "Ваш список желаний пока пуст";

        public PersonalCabinetPage(IWebDriver driver) : base(driver) { }

        public IWebElement LoginField
            => Driver.FindElement(By.Name("login"));

        public IWebElement PasswordField
            => Driver.FindElement(By.Name("password"));
    
        public IWebElement LoginButton
            => Driver.FindElement(By.XPath("//div[@class='signup-submit']/button/span"));

        public IWebElement WishlistLink
            => Driver.FindElement(By.XPath("//li[@class='profile-m-i'][3]/a"));

        public IWebElement EmptyWishlistHeader
            => Driver.FindElement(By.XPath("//h3[@class='wishlist-i-empty-title']"));

        public IWebElement FirstWishListButton
            => Driver.FindElement(By.Id("firstlist_button"));

        public MenuBar MenuBar
          => new MenuBar(Driver.FindElement(By.ClassName("flex")));


    }
}
