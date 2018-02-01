namespace Framework.Infrastructure.Controls
{
    class Form : HtmlControl, IForm
    {
        public string GetText
        {
            get { return Text; }
        }

        new public bool Displayed
        {
            get { return Displayed; }
        }
    }
}
