namespace Eumel.EmailCategorizer.Persister
{
    public class StaticConfigPersister : IConfigPersister
    {
        private readonly TopicParserConfiguration _config;

        public StaticConfigPersister()
        {
            _config = new TopicParserConfiguration("[", "]");
        }

        #region Implementation of IConfigPersister

        /// <summary>
        ///     get a list of topics
        /// </summary>
        public TopicParserConfiguration GetConfig()
        {
            return _config;
        }

        /// <summary>
        ///     set a list of topics. this list replaces the existing list
        /// </summary>
        public void SetConfig(TopicParserConfiguration topicParserConfiguration)
        {
            // wont be implemented. config will always be with []
        }

        #endregion Implementation of IConfigPersister
    }
}