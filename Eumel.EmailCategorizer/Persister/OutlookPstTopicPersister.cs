using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Interop.Outlook;

namespace Eumel.EmailCategorizer.Persister
{
    class OutlookPstTopicPersister : ITopicPersister
    {
        private const string TopicDataString = "Topics";
        private const string TopicTitleDescriptionSeperator = "??";
        private const string TopicSeperator = "|";

        private readonly StorageItem _storage;

        public OutlookPstTopicPersister(StorageItem storage)
        {
            _storage = storage;
        }

        #region Implementation of ITopicPersister

        /// <summary>
        /// get a list of topics
        /// </summary>
        public IEnumerable<Topic> GetTopics()
        {
            if (_storage.Size == 0)
            {
                _storage.UserProperties.Add(TopicDataString, OlUserPropertyType.olText);
                _storage.UserProperties[TopicDataString].Value = string.Empty;
                _storage.Save();
            }

            var topicStrings = ((string)_storage.UserProperties[TopicDataString].Value)
                        .Split(new[] { TopicSeperator }, StringSplitOptions.RemoveEmptyEntries);

            var topics = from t in topicStrings
                         let parts = (t + TopicTitleDescriptionSeperator).Split(new[] { TopicTitleDescriptionSeperator }, StringSplitOptions.None)
                         select new Topic() { Title = parts[0], Description = parts[1] };

            return topics;
        }

        /// <summary>
        /// set a list of topics. this list replaces the existing list
        /// </summary>
        public void SetTopics(IEnumerable<Topic> topics)
        {
            var topicStrings = from t in topics
                               select t.Title + TopicTitleDescriptionSeperator + t.Description;

            var data = String.Join(TopicSeperator, topicStrings);

            _storage.UserProperties[TopicDataString].Value = string.Join(TopicSeperator, data);
            _storage.Save();
        }

        /// <summary>
        /// add the topic to the store
        /// </summary>
        // ReSharper disable PossibleMultipleEnumeration
        public void AddTopic(Topic topic)
        {
            // only for non-empty topics
            if (topic == null || string.IsNullOrWhiteSpace(topic.Title)) return;

            var topics = this.GetTopics();
            var existingTopics = topics.Select(t => t.Title);

            if (existingTopics.Contains(topic.Title)) return;

            var lst = topics.Concat(new[] { topic });
            SetTopics(lst);
        }
        // ReSharper restore PossibleMultipleEnumeration

        #endregion
    }
}
