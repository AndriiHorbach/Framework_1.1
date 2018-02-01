namespace Framework.Infrastructure.Pages
{
    using global::Framework.Infrastructure.Controls;
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using System.Linq;

    class MenuBar : HtmlControl
    {
        private IWebElement Root;
        public MenuBar(IWebElement element)
            => Root = element;
        public IEnumerable <IWebElement> Menu => Root.FindElements(By.ClassName("whitelink"));

        public IWebElement SelectMenuPoint(string linkName)
            => Menu.First(e => e.Text.Contains(linkName));
    }
}