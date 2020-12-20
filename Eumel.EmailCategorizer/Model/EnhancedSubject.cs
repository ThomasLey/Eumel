using Eumel.EmailCategorizer.Extensions;
using Eumel.EmailCategorizer.Persister;

namespace Eumel.EmailCategorizer.Model
{
    /// <summary>
    ///     subject with enhanced functionality to separate topic and subject text.
    /// </summary>
    public class EnhancedSubject
    {
        private readonly TopicParserConfiguration _config;

        public EnhancedSubject(string subjectToParse, TopicParserConfiguration config)
        {
            _config = config;
            Subject = subjectToParse;

            Parse();
        }

        public Topic Topic { get; set; }

        public string Subject { get; set; }

        public override string ToString()
        {
            if (Topic?.Title?.IsNullOrWhiteSpace() ?? true) return Subject;
            return $"{_config.TopicStart}{Topic.Title}{_config.TopicEnd} {Subject}";
        }

        private void Parse()
        {
            // get topic of email and remove topic
            var tmpTopic = Subject.Between(_config.TopicStart, _config.TopicEnd)
                .Trim();
            Topic = new Topic {Title = tmpTopic};

            // get subject w/o topic
            Subject = Subject
                .Replace(_config.TopicStart + tmpTopic + _config.TopicEnd, "")
                .Trim()
                .Replace("  ", " ").Replace("  ", " "); // replace all multiple spaces.
        }
    }
}