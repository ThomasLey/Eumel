namespace Eumel.EmailCategorizer.Core.Model
{
    public class TopicParserConfiguration
    {
        public TopicParserConfiguration(string topicStart, string topicEnd)
        {
            TopicStart = topicStart;
            TopicEnd = topicEnd;
        }

        public string TopicStart { get; set; }
        public string TopicEnd { get; set; }
    }
}