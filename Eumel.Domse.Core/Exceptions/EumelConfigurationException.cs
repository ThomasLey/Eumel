namespace Eumel.Domse.Core.Exceptions
{
    public class EumelConfigurationException : EumelException
    {
        public override int ErrorId { get; } = 1000;

        public string Store { get; }

        public EumelConfigurationException(string messages, string store)
            : base(messages)
        {
            Store = store;
        }
    }
}