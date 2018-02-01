namespace Framework.Infrastructure.Controls
{
    class Input : HtmlControl, IInput
    {
        public void SetText (string text)
        {
            Clear();
            SendKeys(text);
        }

        new public void Submit()
        {
            base.Submit();
        }

        new public bool Displayed
        {
            get { return base.Displayed; }
        }
    }
}
