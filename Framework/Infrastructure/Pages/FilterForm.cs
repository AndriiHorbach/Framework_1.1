namespace Framework.SharedSteps
{
    using System.Linq;
    using OpenQA.Selenium;
    using System.Collections.Generic;

    public class FiltersForm
    {
        private IWebElement Root;
        public FiltersForm(IWebElement element)
            => Root = element;
        public IEnumerable<IWebElement> FiltersSections => Root.FindElements(By.ClassName("filter-parametrs-i"));
        //public IEnumerable<IWebElement> FiltersSections => Root.FindElements(By.Id("filter-parametrs-form"));
        public IEnumerable<IWebElement> ItemsForSection(string sectionName)
            => new FilterSection(FiltersSections.First(i => i.FindElement(By.Name("filter_parameters_title")).Text.Contains(sectionName))).Items;
    }

    public class FilterSection
    {
        private IWebElement Root;
        public FilterSection(IWebElement element) => Root = element;
        public IEnumerable <IWebElement> Items => Root.FindElements(By.CssSelector("li.pos-fix"));
    }


    
}
