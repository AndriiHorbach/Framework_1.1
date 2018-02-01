namespace Framework.Infrastructure.Controls
{
    interface IInput : IElement
    {
        void SetText(string text);

        void Submit();

    }
}
