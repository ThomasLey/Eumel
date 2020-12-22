using System.Collections.Generic;
using Eumel.EmailCategorizer.Core.Model;

namespace Eumel.EmailCategorizer.Core
{
    /// <summary>
    ///     interface to manage the topics
    /// </summary>
    public interface ITopicPersister
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