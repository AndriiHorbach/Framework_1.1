using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Infrastructure.Controls.Interfaces
{
    interface IElement : IWebElement, IWrapsElement
    {
    }
}
