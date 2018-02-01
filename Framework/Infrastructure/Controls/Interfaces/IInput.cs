namespace Framework.Infrastructure.Controls.Interfaces
{
    interface IInput : IElement
    {
        void SetText(string text);

        void Submit();

    }
}
