using Framework.Infrastructure.Controls.Interfaces;

namespace Framework.Infrastructure.Controls.Elements
{
    class Input : HtmlControl, IInput
    {
        public void SetText (string text)
        {
            Clear();
            SendKeys(text);
        }

        public new void Submit()
        {
            base.Submit();
        }

        public new bool Displayed => base.Displayed;
    }
}
