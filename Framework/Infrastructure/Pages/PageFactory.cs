namespace Framework.Infrastructure.Pages
{
    using SeleniumDriver;
    using global::Framework.Infrastructure.Controls.New;

    public static class PageFactory
    {
        public static T GetPage<T>() where T : new()
        {
            var page = new T();
            //var decor = new Decorator();
            OpenQA.Selenium.Support.PageObjects.PageFactory.InitElements(SeleniumDriver.GetDriver(), page);
            return page;
        }

    }
}
