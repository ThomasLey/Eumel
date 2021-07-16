using System.Collections.Generic;

namespace Eumel.Domse.BusinessLogic
{
    public class FileConfigProvider : ISettingsProvider
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
}