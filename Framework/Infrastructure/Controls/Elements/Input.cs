using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using System.Threading.Tasks;

namespace Framework.Infrastructure.Controls.New
{
    class Input : Decorator
    {
        private IWebElement wrappedElement;

        public void SetText(string text)
        {
            wrappedElement.Clear();
            wrappedElement.SendKeys(text);           
        }

    }
}
