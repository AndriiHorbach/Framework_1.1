using System.Collections.ObjectModel;
using Framework.Infrastructure.Common;
using OpenQA.Selenium;

namespace Framework.Infrastructure.Controls.Elements
{
    public class HtmlControl
    {
        internal By Locator;

        private IWebElement WrappedElement => SeleniumDriver.GetDriver().FindElement(Locator);

        protected string Text => WrappedElement.Text;

        public bool Displayed => WrappedElement.Displayed;

        public void Clear()
            => WrappedElement.Clear();

        protected void Click()
            => WrappedElement.Click();

        public IWebElement FindElement(By by)
        {
            return WrappedElement.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return WrappedElement.FindElements(by);
        }

        protected void SendKeys(string text)
            => WrappedElement.SendKeys(text);

        protected void Submit()
            => WrappedElement.Submit();
    }
}
