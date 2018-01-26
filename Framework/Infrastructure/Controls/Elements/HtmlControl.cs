using System;
using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using Framework.SeleniumDriver;
using Framework.Infrastructure.Controls.Interfaces;

namespace Framework.Infrastructure.Controls.New
{
    public class HtmlControl : IElement
    {
        private readonly IWebElement MyWrappedElement;
        private ISearchContext Driver;

        public HtmlControl(IWebElement webElement) 
            => MyWrappedElement = webElement;
        

        public string TagName => throw new NotImplementedException();

        public string Text => throw new NotImplementedException();

        public bool Enabled => throw new NotImplementedException();

        public bool Selected => throw new NotImplementedException();

        public Point Location => throw new NotImplementedException();

        public Size Size => throw new NotImplementedException();

        public bool Displayed => throw new NotImplementedException();

        IWebElement IWrapsElement.WrappedElement
        {
            get
            {
                return MyWrappedElement is IWrapsElement
                    ? (MyWrappedElement as IWrapsElement).WrappedElement
                    : MyWrappedElement;
            }
        }

        public void Clear()
            => MyWrappedElement.Clear();

        public void Click()
            => MyWrappedElement.Click();

        public IWebElement FindElement(By by)
        {
            return MyWrappedElement.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return MyWrappedElement.FindElements(by);
        }

        public string GetAttribute(string attributeName)
        {
            return MyWrappedElement.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return MyWrappedElement.GetCssValue(propertyName);
        }

        public string GetProperty(string propertyName)
        {
            return MyWrappedElement.GetProperty(propertyName);
        }

        public void SendKeys(string text)
            => MyWrappedElement.SendKeys(text);

        public void Submit()
            => MyWrappedElement.Submit();
    }
}
