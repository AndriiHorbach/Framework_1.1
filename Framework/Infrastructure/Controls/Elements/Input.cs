using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using System.Threading.Tasks;

namespace Framework.Infrastructure.Controls.New
{
    class Input : HtmlControl
    {
        
        public void SetText(string text)
        {
            control.Clear();
            control.SendKeys(text);           
        }

    }
}
