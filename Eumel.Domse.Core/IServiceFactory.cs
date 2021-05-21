namespace Eumel.Domse.Core
{
    public interface IServiceFactory
    {
        IStorageService GetStorage();
    }
}