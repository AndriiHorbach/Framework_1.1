namespace Framework.Pages
{
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using System.Linq;

    class MenuBar
    {
        private IWebElement Root;
        public MenuBar(IWebElement element)
            => Root = element;
        public IEnumerable <IWebElement> Menu => Root.FindElements(By.ClassName("novisited"));
        public IWebElement SelectMenuPoint(string linkName)
            => Menu.First(e => e.Text.Contains(linkName));
    }
}