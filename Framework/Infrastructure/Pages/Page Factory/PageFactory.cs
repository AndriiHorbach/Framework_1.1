namespace Framework.Infrastructure.Pages
{
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium;
    using System.Reflection;
    using static System.Reflection.BindingFlags;
    using static System.Activator;
    using System.Linq;
    using Framework.Infrastructure.Controls;

    public static class PageFactory
    {
        const BindingFlags NonPublicInstance = NonPublic | Instance;

        public static T GetPage<T>()
        {
            var page = CreateInstance<T>();
            typeof(T).GetFields(Public | NonPublicInstance)
                .ToList()
                .ForEach(field =>
                {
                    var fieldType = field.FieldType;
                    var attributes = field.GetCustomAttributes<FindsByAttribute>();
                    if (attributes.Any())
                    {
                        var obj = CreateInstance(fieldType);
                        var attribute = attributes.Single();
                        fieldType.GetField(nameof(HtmlControl.Locator), NonPublicInstance)
                            .SetValue(obj, typeof(By)
                                .GetMethod(attribute.How.ToString(), Public | Static)
                                .Invoke(null, new object[] { attribute.Using }));
                        field.SetValue(page, obj);
                    }
                });
            return page;
        }
    }
}
