namespace Framework.Infrastructure.Pages
{
    using SeleniumDriver;
    using global::Framework.Infrastructure.Controls.New;
    using OpenQA.Selenium.Support.PageObjects;

    public static class PageFactory
    {
        public static T GetPage<T>() where T : new()
        {
            var page = new T();
            OpenQA.Selenium.Support.PageObjects.PageFactory.InitElements(SeleniumDriver.GetDriver(), page, new Decorator());
            return page;
        }

    }
}
