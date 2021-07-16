using System;
using System.Collections.Generic;

namespace Eumel.Domse.BusinessLogic
{
    public class SettingsOperator : ISettingsOperator
    {
        private readonly IAggregateSettingsProvider _settingsProvider;

        public SettingsOperator(IAggregateSettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        public IDictionary<string, string> GetSettings()
        {
            throw new NotImplementedException();
        }
    }
}