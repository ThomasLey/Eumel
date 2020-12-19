using Eumel.EmailCategorizer.Model;
using System.Collections.Generic;

namespace Eumel.EmailCategorizer.Persister
{
    /// <summary>
    ///     interface to manage the topics
    /// </summary>
    internal interface ITopicPersister
    {
        /// <summary>
        ///     get a list of topics
        /// </summary>
        IEnumerable<Topic> GetTopics();

        /// <summary>
        ///     set a list of topics. this list replaces the existing list
        /// </summary>
        void SetTopics(IEnumerable<Topic> topics);

        /// <summary>
        ///     add the topic to the store
        /// </summary>
        void AddTopic(Topic topic);
    }
}