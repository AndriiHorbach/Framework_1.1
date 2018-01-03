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

        /// <summary>
        /// Initializes a new instance of the <see cref="WebElementListProxy"/> class.
        /// </summary>
        /// <param name="typeToBeProxied">The <see cref="Type"/> of object for which to create a proxy.</param>
        /// <param name="locator">The <see cref="IElementLocator"/> implementation that
        /// determines how elements are located.</param>
        /// <param name="bys">The list of methods by which to search for the elements.</param>
        /// <param name="cache"><see langword="true"/> to cache the lookup to the element; otherwise, <see langword="false"/>.</param>
        private WebElementListProxy(Type typeToBeProxied, IElementLocator locator, IEnumerable<By> bys, bool cache)
            : base(typeToBeProxied, locator, bys, cache)
        {
        }

        /// <summary>
        /// Gets the list of IWebElement objects this proxy represents, returning a cached one if requested.
        /// </summary>
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

        /// <summary>
        /// Creates an object used to proxy calls to properties and methods of the
        /// list of <see cref="IWebElement"/> objects.
        /// </summary>
        /// <param name="classToProxy">The <see cref="Type"/> of object for which to create a proxy.</param>
        /// <param name="locator">The <see cref="IElementLocator"/> implementation that
        /// determines how elements are located.</param>
        /// <param name="bys">The list of methods by which to search for the elements.</param>
        /// <param name="cacheLookups"><see langword="true"/> to cache the lookup to the
        /// element; otherwise, <see langword="false"/>.</param>
        /// <returns>An object used to proxy calls to properties and methods of the
        /// list of <see cref="IWebElement"/> objects.</returns>
        public static object CreateProxy(Type classToProxy, IElementLocator locator, IEnumerable<By> bys, bool cacheLookups)
        {
            return new WebElementListProxy(classToProxy, locator, bys, cacheLookups).GetTransparentProxy();
        }

        /// <summary>
        /// Invokes the method that is specified in the provided <see cref="IMessage"/> on the
        /// object that is represented by the current instance.
        /// </summary>
        /// <param name="msg">An <see cref="IMessage"/> that contains an <see cref="IDictionary"/>  of
        /// information about the method call. </param>
        /// <returns>The message returned by the invoked method, containing the return value and any
        /// out or ref parameters.</returns>
        public override IMessage Invoke(IMessage msg)
        {
            var elements = this.ElementList;
            return WebDriverObjectProxy.InvokeMethod(msg as IMethodCallMessage, elements);
        }
    }
}
