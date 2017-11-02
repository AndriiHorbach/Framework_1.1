namespace Framework.Controls
{
    using OpenQA.Selenium;

    class HtmlInput
    {
        public void SendKeys(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public void Submit(IWebElement element)
            => element.Submit();            
    }
}
