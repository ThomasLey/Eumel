using System.Collections.Generic;
using System.Linq;

namespace Eumel.Domse.BusinessLogic
{
    public class DefaultAggregateSettingsProvider : IAggregateSettingsProvider
    {
        private readonly ISettingsProvider[] _settingsProviders;

        public DefaultAggregateSettingsProvider(IEnumerable<ISettingsProvider> SettingsProviders)
        {
            _settingsProviders = SettingsProviders.OrderBy(x => x.Order).ToArray();
        }

        public int Order => 0;

        public string this[string name] => _settingsProviders.Select(x => x[name]).FirstOrDefault(x => x != default);
    }
}