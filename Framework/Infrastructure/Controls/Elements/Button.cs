using Framework.Infrastructure.Controls.Interfaces;

namespace Framework.Infrastructure.Controls.Elements
{
    class Button : HtmlControl, IButton
    {
       public new void Click()
           => base.Click();

       public new bool Displayed => base.Displayed;
    }
}
