using Eumel.EmailCategorizer.Core.Model;

namespace Eumel.EmailCategorizer.Core.Impl
{
    public class ConfigPersister : IConfigPersister
    {
        private const string ConfigDataString = "Config";
        private IEumelStorageItem _storage;

        public ConfigPersister(IEumelStorageItem storage)
        {
            _storage = storage;
        }

        #region Implementation of IConfigPersister

        /// <summary>
        ///     get a list of topics
        /// </summary>
        public TopicParserConfiguration GetConfig()
        {
            return new TopicParserConfiguration("[", "]");
        }

        /// <summary>
        ///     set a list of topics. this list replaces the existing list
        /// </summary>
        public void SetConfig(TopicParserConfiguration topicParserConfiguration)
        {
            // todo implement
        }

        #endregion Implementation of IConfigPersister
    }
}