using System;
using System.Runtime.Serialization;

namespace BaseDomainObjects.Exceptions
{
    [Serializable]
    class InvalidAggregateVersionException : Exception
    {
        public InvalidAggregateVersionException()
        {
        }

        public InvalidAggregateVersionException(string message) : base(message)
        {
        }

        public InvalidAggregateVersionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAggregateVersionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}