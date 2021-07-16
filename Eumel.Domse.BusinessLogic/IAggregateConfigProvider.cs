using System;
using System.Collections.Generic;
using System.Linq;

namespace Eumel.Domse.BusinessLogic
{
    public class DefaultAggregateConfigProvider : IAggregateConfigProvider
    {
        private readonly IConfigProvider[] _configProviders;

        public DefaultAggregateConfigProvider(IEnumerable<IConfigProvider> configProviders)
        {
            _configProviders = configProviders.OrderBy(x => x.Order).ToArray();
        }

        public int Order => 0;

        public string this[string name] => _configProviders.Select(x => x[name]).FirstOrDefault(x => x != default);
    }

    public class FileConfigProvider : IConfigProvider
    {
        private readonly string _file;
        private IDictionary<string, string> _configuration = new Dictionary<string, string>();

        public FileConfigProvider(string file, int order)
        {
            _file = file;
            Order = order;
        }
        public int Order { get; }

        public string this[string name] => _configuration.ContainsKey(name) ? _configuration[name] : default;
    }

    public interface IAggregateConfigProvider : IConfigProvider
    {
    }

    public interface IConfigProvider : IOrderable
    {
        string this[string name] { get; }
    }

    public interface IOrderable
    {
        int Order { get; }
    }
}