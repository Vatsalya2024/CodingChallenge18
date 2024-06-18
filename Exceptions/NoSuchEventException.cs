using System.Runtime.Serialization;

namespace CodingChallenge.Exceptions
{
    [Serializable]
    internal class NoSuchEventException : Exception
    {
        public NoSuchEventException()
        {
        }

        public NoSuchEventException(string? message) : base(message)
        {
        }

        public NoSuchEventException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoSuchEventException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}