using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using System.Threading.Tasks;

namespace Framework.Infrastructure.Controls.New
{
    class Input : HtmlControl
    {
        public Input(IWebElement webElement) : base(webElement)
        {
        }
    }
}
