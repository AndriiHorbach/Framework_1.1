namespace Framework.Infrastructure.Pages
{
    using SeleniumDriver;
    using global::Framework.Infrastructure.Controls.New;
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium;
    using System;
    using global::Framework.Infrastructure.Controls.Interfaces;

    public static class PageFactory
    {
        public static T GetPage<T>() where T : new()
        {
            var page = new T();
            InitElements(SeleniumDriver.GetDriver(), page);
            return page;
        }

        private static HtmlControl InitElements(ISearchContext searchContext, object pageObject)
        {
            //if (pageObject == null)
            //{
            //   throw new ArgumentNullException("pageObject");
            //}
            //
            //if (searchContext == null)
            //{
            //    throw new ArgumentNullException("searchContext");
            //}

            var type = pageObject.GetType();
            pageObject.


            if (type == typeof(IWebElement) || type == typeof(IElement))
            {
                var a =  new HtmlControl(searchContext as IElement);
                return a;
            }

            return new HtmlControl(searchContext as IWebElement);
        }

        //private By CreateElementLocator(MemberInfo memberInfo)
        //{
        //    var attributes = memberInfo.GetCustomAttributes(typeof(FindsByAttribute), true);

        //    if (attributes.Length == 0)
        //    {
        //        return ByFactory.Create(How.Id, memberInfo.Name);
        //    }

        //    if (attributes.Length > 1)
        //    {
        //        var errorBuilder = new StringBuilder();

        //        errorBuilder.AppendFormat(
        //            "Multiple attributes [{0}] found on [{1}] which is member of [{2}] class.",
        //            typeof(FindsByAttribute), memberInfo.Name, memberInfo.DeclaringType);

        //        errorBuilder.AppendFormat(
        //            "Having multiple attribute for a single class member is not supported by [{0}].", this);

        //        throw new ArgumentException(errorBuilder.ToString(), "memberInfo");
        //    }

        //    return ByFactory.Create(attributes[0] as FindsByAttribute);
        //}





    }
}
