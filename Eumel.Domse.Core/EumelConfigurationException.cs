namespace Eumel.Domse.Core
{
    public class EumelConfigurationException : EumelException
    {
        public const string ErrorId = "1000";
        public const string ErrorMessage = "Invalid configuration:";

        private readonly string _messages;

        public EumelConfigurationException(string messages)
        {
            _messages = messages;
        }
    }
}