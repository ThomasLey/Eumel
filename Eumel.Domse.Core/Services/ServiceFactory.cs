using Eumel.Domse.Core.Contracts;
using Eumel.Domse.Core.Model;

namespace Eumel.Domse.Core.Services
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