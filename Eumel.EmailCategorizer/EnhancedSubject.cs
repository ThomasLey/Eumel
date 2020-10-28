using Eumel.EmailCategorizer.Extensions;
using Eumel.EmailCategorizer.Persister;

namespace Eumel.EmailCategorizer
{
    public class EnhancedSubject
    {
        private readonly TopicParserConfiguration _topicParserConfiguration;

        public EnhancedSubject(string subjectToParse, TopicParserConfiguration topicParserConfiguration)
        {
            _topicParserConfiguration = topicParserConfiguration;
            Subject = subjectToParse;

            Parse();
        }

        private void Parse()
        {
            // get topic of email and remove topic
            var tmpTopic = Subject.Between(_topicParserConfiguration.TopicStart, _topicParserConfiguration.TopicEnd).Trim();
            Topic=new Topic() {Title = tmpTopic};

            // get subject w/o topic
            Subject = Subject.Replace(_topicParserConfiguration.TopicStart + tmpTopic + _topicParserConfiguration.TopicEnd, "")
                .Trim()
                .Replace("  ", " ").Replace("  ", " "); // replace all multiple spaces.
        }

        public Topic Topic { get; set; }

        public string Subject { get; set; }
    }
}