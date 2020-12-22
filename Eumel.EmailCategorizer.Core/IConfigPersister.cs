using Eumel.EmailCategorizer.Core.Model;

namespace Eumel.EmailCategorizer.Core
{
    /// <summary>
    ///     interface to manage the topics
    /// </summary>
    public interface IConfigPersister
    {
        /// <summary>
        ///     get a list of topics
        /// </summary>
        TopicParserConfiguration GetConfig();

        /// <summary>
        ///     set a list of topics. this list replaces the existing list
        /// </summary>
        void SetConfig(TopicParserConfiguration topicParserConfiguration);
    }
}