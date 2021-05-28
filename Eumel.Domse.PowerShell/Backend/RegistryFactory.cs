using System;
using StructureMap;

namespace Eumel.Domse.PowerShell.Backend
{
    public class RegistryFactory
    {
        public RegistryFactory(string store)
        {
            if (store.StartsWith("http", StringComparison.InvariantCultureIgnoreCase))
                throw new NotSupportedException("http/https access is currently not supported.");

            Registry = new FileSystemRegistry(store);
        }

        public Registry Registry { get; }
    }
}