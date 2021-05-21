namespace Eumel.Domse.Core
{
    public class ServiceFactory : IServiceFactory
    {
        private readonly EumelConfiguration _config;

        public ServiceFactory(string configFile)
        {
            _config = EumelConfiguration.Load(configFile);
        }

        public IStorageService GetStorage()
        {
            if (_config.StorageType == "FolderStorageService")
                return new FolderStorageService(_config.StorageEndpoint);

            return null;
        }
    }
}