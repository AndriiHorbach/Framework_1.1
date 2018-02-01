namespace Framework.Infrastructure.Controls
{
    class Button : HtmlControl, IButton
    {
       new public void Click()
           => base.Click();

       new public bool Displayed
       {
            get { return base.Displayed; }
       }
    }
}
