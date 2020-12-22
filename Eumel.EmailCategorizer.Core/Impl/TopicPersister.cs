using System;
using System.Collections.Generic;
using System.Linq;
using Eumel.EmailCategorizer.Core.Model;

namespace Eumel.EmailCategorizer.Core.Impl
{
    public class TopicPersister : ITopicPersister
    {
        private const string TopicDataString = "Topics";
        private const string TopicTitleDescriptionSeparator = "??";
        private const string TopicSeparator = "|";

        private readonly IEumelStorageItem _storage;

        public TopicPersister(IEumelStorageItem storage)
        {
            _storage = storage;
        }

        /// <summary>
        ///     get a list of topics
        /// </summary>
        public IEnumerable<Topic> GetTopics()
        {
            var topicStrings = _storage[TopicDataString]
                .Split(new[] {TopicSeparator}, StringSplitOptions.RemoveEmptyEntries);

            var topics = from t in topicStrings
                let parts = (t + TopicTitleDescriptionSeparator).Split(new[] {TopicTitleDescriptionSeparator},
                    StringSplitOptions.None)
                select new Topic {Title = parts[0], Description = parts[1]};

            return topics;
        }

        /// <summary>
        ///     set a list of topics. this list replaces the existing list
        /// </summary>
        public void SetTopics(IEnumerable<Topic> topics)
        {
            var topicStrings = from t in topics
                select t.Title + TopicTitleDescriptionSeparator + t.Description;

            var data = string.Join(TopicSeparator, topicStrings);

            _storage[TopicDataString] = string.Join(TopicSeparator, data);
        }

        /// <summary>
        ///     add the topic to the store
        /// </summary>
        public void AddTopic(Topic topic)
        {
            // only for non-empty topics
            if (topic == null || string.IsNullOrWhiteSpace(topic.Title)) return;

            var topics = GetTopics().ToArray();
            var existingTopics = topics.Select(t => t.Title);

            if (existingTopics.Contains(topic.Title)) return;

            var lst = topics.Concat(new[] {topic});
            SetTopics(lst);
        }
    }
}