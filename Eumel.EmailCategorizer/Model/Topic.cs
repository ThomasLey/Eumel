namespace Eumel.EmailCategorizer.Model
{
    /// <summary>
    ///     entity for a topic
    /// </summary>
    public class Topic
    {
        /// <summary>
        ///     title of the topic (for the subject)
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     description for the topic with further details
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     return the topic as string
        /// </summary>
        public override string ToString()
        {
            return Title;
        }
    }
}