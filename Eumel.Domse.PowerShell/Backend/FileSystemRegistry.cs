using System.IO.Abstractions;
using Eumel.Domse.Core.Contracts;
using Eumel.Domse.Core.Exceptions;
using Eumel.Domse.Core.Model;
using Eumel.Domse.Core.Services;
using NJsonSchema.Annotations;
using StructureMap;

namespace Eumel.Domse.PowerShell.Backend
{
    public class FileSystemRegistry : Registry
    {
        private readonly IFileSystem _fileSystem;

        private EumelConfiguration ReadConfiguration([NotNull] string folder)
        {
            var source = _fileSystem.Path.Combine(folder, ".eumel.config.json");
            if (!System.IO.File.Exists(source))
            {
                throw new EumelConfigurationException("cannot find configuration file", source);
            }

            return EumelConfiguration.Load(source);
        }

        public FileSystemRegistry(string store, IFileSystem fileSystem = null)
        {
            _fileSystem = fileSystem ?? new FileSystem();

            For<EumelConfiguration>().Use(ReadConfiguration(store));
            For<IStorageService>().Use<FolderStorageService>().Singleton();
        }
    }
}