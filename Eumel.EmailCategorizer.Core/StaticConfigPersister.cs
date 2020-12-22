using Eumel.EmailCategorizer.Core.Model;

namespace Eumel.EmailCategorizer.Core
{
    public class StaticConfigPersister : IConfigPersister
    {
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
            // wont be implemented. config will always be with []
        }

        #endregion Implementation of IConfigPersister
    }
}