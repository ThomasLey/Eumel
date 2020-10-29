namespace Eumel.EmailCategorizer.Persister
{
    public class TopicParserConfiguration
    {
        public TopicParserConfiguration()
        {
        }

        public TopicParserConfiguration(string topicStart, string topicEnd) : this()
        {
            TopicStart = topicStart;
            TopicEnd = topicEnd;
        }

        public string TopicStart { get; set; }
        public string TopicEnd { get; set; }
    }
}