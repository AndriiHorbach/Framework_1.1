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
        private static List<Type> interfacesToBeProxied;
        private static Type interfaceProxyType;

        private static List<Type> InterfacesToBeProxied
        {
            get
            {
                if (interfacesToBeProxied == null)
                {
                    interfacesToBeProxied = new List<Type>();
                    interfacesToBeProxied.Add(typeof(IWebElement));
                    interfacesToBeProxied.Add(typeof(ILocatable));
                    interfacesToBeProxied.Add(typeof(IWrapsElement));
                }

                return interfacesToBeProxied;
            }
        }

        private static Type InterfaceProxyType
        {
            get
            {
                if (interfaceProxyType == null)
                {
                    interfaceProxyType = CreateTypeForASingleElement();
                }

                return interfaceProxyType;
            }
        }

        /// <summary>
        /// Locates an element or list of elements for a Page Object member, and returns a
        /// proxy object for the element or list of elements.
        /// </summary>
        /// <param name="member">The <see cref="MemberInfo"/> containing information about
        /// a class's member.</param>
        /// <param name="locator">The <see cref="IElementLocator"/> used to locate elements.</param>
        /// <returns>A transparent proxy to the WebDriver element object.</returns>
        public object Decorate(MemberInfo member, IElementLocator locator)
        {
            FieldInfo field = member as FieldInfo;
            PropertyInfo property = member as PropertyInfo;

            Type targetType = null;
            if (field != null)
            {
                targetType = field.FieldType;
            }

            bool hasPropertySet = false;
            if (property != null)
            {
                hasPropertySet = property.CanWrite;
                targetType = property.PropertyType;
            }

            if (field == null & (property == null || !hasPropertySet))
            {
                return null;
            }

            IList<By> bys = CreateLocatorList(member);
            if (bys.Count > 0)
            {
                bool cache = ShouldCacheLookup(member);
                object proxyObject = CreateProxyObject(targetType, locator, bys, cache);
                return proxyObject;
            }

            return null;
        }

        /// <summary>
        /// Determines whether lookups on this member should be cached.
        /// </summary>
        /// <param name="member">The <see cref="MemberInfo"/> containing information about
        /// the member of the Page Object class.</param>
        /// <returns><see langword="true"/> if lookups are to be cached; otherwise, <see langword="false"/>.</returns>
        protected static bool ShouldCacheLookup(MemberInfo member)
        {
            if (member == null)
            {
                throw new ArgumentNullException("member", "memeber cannot be null");
            }

            var cacheAttributeType = typeof(CacheLookupAttribute);
            bool cache = member.GetCustomAttributes(cacheAttributeType, true).Length != 0 || member.DeclaringType.GetCustomAttributes(cacheAttributeType, true).Length != 0;
            return cache;
        }

        /// <summary>
        /// Creates a list of <see cref="By"/> locators based on the attributes of this member.
        /// </summary>
        /// <param name="member">The <see cref="MemberInfo"/> containing information about
        /// the member of the Page Object class.</param>
        /// <returns>A list of <see cref="By"/> locators based on the attributes of this member.</returns>
        protected static ReadOnlyCollection<By> CreateLocatorList(MemberInfo member)
        {
            if (member == null)
            {
                throw new ArgumentNullException("member", "memeber cannot be null");
            }

            var useSequenceAttributes = Attribute.GetCustomAttributes(member, typeof(FindsBySequenceAttribute), true);
            bool useSequence = useSequenceAttributes.Length > 0;

            var useFindAllAttributes = Attribute.GetCustomAttributes(member, typeof(FindsByAllAttribute), true);
            bool useAll = useFindAllAttributes.Length > 0;

            if (useSequence && useAll)
            {
                throw new ArgumentException("Cannot specify FindsBySequence and FindsByAll on the same member");
            }

            List<By> bys = new List<By>();
            var attributes = Attribute.GetCustomAttributes(member, typeof(FindsByAttribute), true);
            if (attributes.Length > 0)
            {
                Array.Sort(attributes);
                foreach (var attribute in attributes)
                {
                    var castedAttribute = (FindsByAttribute)attribute;
                    if (castedAttribute.Using == null)
                    {
                        castedAttribute.Using = member.Name;
                    }

                    //bys.Add(castedAttribute.Finder);
                }

                if (useSequence)
                {
                    ByChained chained = new ByChained(bys.ToArray());
                    bys.Clear();
                    bys.Add(chained);
                }

                if (useAll)
                {
                    ByAll all = new ByAll(bys.ToArray());
                    bys.Clear();
                    bys.Add(all);
                }
            }

            return bys.AsReadOnly();
        }

        private static object CreateProxyObject(Type memberType, IElementLocator locator, IEnumerable<By> bys, bool cache)
        {
            object proxyObject = null;
            if (memberType == typeof(IList<IWebElement>))
            {
                foreach (var type in InterfacesToBeProxied)
                {
                    Type listType = typeof(IList<>).MakeGenericType(type);
                    if (listType.Equals(memberType))
                    {
                        proxyObject = WebElementListProxy.CreateProxy(memberType, locator, bys, cache);
                        break;
                    }
                }
            }
            else if (memberType == typeof(IWebElement))
            {
                proxyObject = WebElementProxy.CreateProxy(InterfaceProxyType, locator, bys, cache);
            }
            else
            {
                throw new ArgumentException("Type of member '" + memberType.Name + "' is not IWebElement or IList<IWebElement>");
            }

            return proxyObject;
        }

        private static Type CreateTypeForASingleElement()
        {
            AssemblyName tempAssemblyName = new AssemblyName(Guid.NewGuid().ToString());

            AssemblyBuilder dynamicAssembly = AppDomain.CurrentDomain.DefineDynamicAssembly(tempAssemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = dynamicAssembly.DefineDynamicModule(tempAssemblyName.Name);
            TypeBuilder typeBuilder = moduleBuilder.DefineType(typeof(IWebElement).FullName, TypeAttributes.Public | TypeAttributes.Interface | TypeAttributes.Abstract);

            foreach (Type type in InterfacesToBeProxied)
            {
                typeBuilder.AddInterfaceImplementation(type);
            }

            return typeBuilder.CreateType();
        }

    }
}
