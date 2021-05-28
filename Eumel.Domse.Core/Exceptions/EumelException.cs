using System;

namespace Eumel.Domse.Core.Exceptions
{
    public abstract class EumelException : Exception
    {
        public abstract int ErrorId { get; }

        protected EumelException(string message) : base(message) { }

        protected EumelException(string message, Exception innerException) : base(message, innerException) { }
    }
}