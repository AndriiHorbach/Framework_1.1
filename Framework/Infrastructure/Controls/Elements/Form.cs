using Framework.Infrastructure.Controls.Interfaces;

namespace Framework.Infrastructure.Controls.Elements
{
    class Form : HtmlControl, IForm
    {
        public string GetText => Text;
    }
}
