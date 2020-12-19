using Microsoft.Office.Interop.Outlook;

namespace Eumel.EmailCategorizer.Persister
{
    public class OutlookPstConfigPersister : IConfigPersister
    {
        private const string ConfigDataString = "Config";
        private StorageItem _storage;

        public OutlookPstConfigPersister(StorageItem storage)
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