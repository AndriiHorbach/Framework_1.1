using System.Collections.Generic;
using System.Linq;
using Framework.Infrastructure.Controls.Elements;
using OpenQA.Selenium;

namespace Framework.Infrastructure.Pages.Panels
{
    public class FiltersForm : HtmlControl
    {
        private readonly IWebElement _root;
        public FiltersForm(IWebElement element)
            => _root = element;
        public IEnumerable<IWebElement> FiltersSections => _root.FindElements(By.ClassName("filter-parametrs-i"));
        public IEnumerable<IWebElement> ItemsForSection(string sectionName)
            => new FilterSection(FiltersSections.First(i => i.FindElement(By.Name("filter_parameters_title")).Text.Contains(sectionName))).Items;
    }

    public class FilterSection
    {
        private readonly IWebElement _root;
        public FilterSection(IWebElement element) => _root = element;
        public IEnumerable<IWebElement> Items => _root.FindElements(By.CssSelector("li.pos-fix"));
    }
}
