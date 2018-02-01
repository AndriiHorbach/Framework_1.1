using Framework.Infrastructure.Controls.Interfaces;

namespace Framework.Infrastructure.Controls.Elements
{
    class Link : HtmlControl, ILink
    {
        public new void Click()
            => base.Click();        

        public string  GetText => Text;

        public new bool Displayed => base.Displayed;
    }
}
