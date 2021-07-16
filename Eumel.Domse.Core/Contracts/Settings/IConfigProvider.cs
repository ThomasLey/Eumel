namespace Eumel.Domse.BusinessLogic
{
    public interface ISettingsProvider : IOrderable
    {
        string this[string name] { get; }
    }
}