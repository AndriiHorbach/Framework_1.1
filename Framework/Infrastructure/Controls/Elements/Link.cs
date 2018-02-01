namespace Framework.Infrastructure.Controls
{
    class Link : HtmlControl, ILink
    {
        new public void Click()
            => base.Click();        

        public string  GetText
        {
            get { return Text; }
        }

        new public bool Displayed
        {
            get { return base.Displayed; }
        }
    }
}
