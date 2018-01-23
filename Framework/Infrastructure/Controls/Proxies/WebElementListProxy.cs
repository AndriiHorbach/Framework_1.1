using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Infrastructure.Controls.Proxies
{
    public class WebElementListProxy : WebDriverObjectProxy
    {
        private List<IWebElement> collection = null;

        private WebElementListProxy(Type typeToBeProxied, IElementLocator locator, IEnumerable<By> bys, bool cache)
            : base(typeToBeProxied, locator, bys, cache)
        {        }

        private List<IWebElement> ElementList
        {
            get
            {
                if (!this.Cache || this.collection == null)
                {
                    this.collection = new List<IWebElement>();
                    this.collection.AddRange(this.Locator.LocateElements(this.Bys));
                }

                return this.collection;
            }
        }

        public static object CreateProxy(Type classToProxy, IElementLocator locator, IEnumerable<By> bys, bool cacheLookups)
        {
            return new WebElementListProxy(classToProxy, locator, bys, cacheLookups).GetTransparentProxy();
        }

        public override IMessage Invoke(IMessage msg)
        {
            var elements = this.ElementList;
            return WebDriverObjectProxy.InvokeMethod(msg as IMethodCallMessage, elements);
        }
    }
}
