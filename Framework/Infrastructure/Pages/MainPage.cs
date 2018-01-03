namespace Framework.Infrastructure.Pages
{
    using OpenQA.Selenium.Support.PageObjects;
    using Controls.New;

    class MainPage : BasePage
    {
        public string URL = "http://rozetka.com.ua/";

        [FindsBy(How = How.Name, Using = "text")]
         public Input SearchField;          
    }
}
