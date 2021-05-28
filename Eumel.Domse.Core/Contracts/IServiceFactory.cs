namespace Eumel.Domse.Core.Contracts
{
    public interface IServiceFactory
    {
        IStorageService GetStorage();
    }
}