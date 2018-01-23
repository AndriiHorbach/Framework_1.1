using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using OpenQA.Selenium.Internal;
using System.Collections.ObjectModel;
using System.Reflection.Emit;
using Framework.Infrastructure.Controls.Proxies;

namespace Framework.Infrastructure.Controls.New
{
    public class Decorator : IPageObjectMemberDecorator
    {

        public object Decorate(MemberInfo member, IElementLocator locator)
        {
            FieldInfo field = member as FieldInfo;
            PropertyInfo property = member as PropertyInfo;

            Type targetType = null;
            if (field != null)
                targetType = field.FieldType;            

            bool hasPropertySet = false;
            if (property != null)
            {
                hasPropertySet = property.CanWrite;
                targetType = property.PropertyType;
            }

            if (field == null & (property == null || !hasPropertySet))
                return null;            

            return null;
        }

        /// <summary>
        /// Determines whether lookups on this member should be cached.
        /// </summary>
        /// <param name="member">The <see cref="MemberInfo"/> containing information about
        /// the member of the Page Object class.</param>
        /// <returns><see langword="true"/> if lookups are to be cached; otherwise, <see langword="false"/>.</returns>


        /// <summary>
        /// Creates a list of <see cref="By"/> locators based on the attributes of this member.
        /// </summary>
        /// <param name="member">The <see cref="MemberInfo"/> containing information about
        /// the member of the Page Object class.</param>
        /// <returns>A list of <see cref="By"/> locators based on the attributes of this member.</returns>
        //private static object CreateProxyObject(Type memberType, IElementLocator locator, IEnumerable<By> bys, bool cache)
        //{
        //    object proxyObject = null;
        //    proxyObject = WebElementListProxy.CreateProxy(memberType, locator, bys, cache);
        //    return proxyObject;
        //}

    }
}
