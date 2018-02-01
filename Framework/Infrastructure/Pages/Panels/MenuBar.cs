using System.Collections.Generic;
using System.Linq;
using Framework.Infrastructure.Controls.Elements;
using OpenQA.Selenium;

namespace Framework.Infrastructure.Pages.Panels
{
    class MenuBar : HtmlControl
    {
        private readonly IWebElement _root;
        public MenuBar(IWebElement element)
            => _root = element;
        public IEnumerable <IWebElement> Menu => _root.FindElements(By.ClassName("whitelink"));

        public IWebElement SelectMenuPoint(string linkName)
            => Menu.First(e => e.Text.Contains(linkName));
    }
}