namespace Eumel.EmailCategorizer.Core
{
    public interface IEumelStorageItem
    {
        string this[string name] { get; set; }
    }
}