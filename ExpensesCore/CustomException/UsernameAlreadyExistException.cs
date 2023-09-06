
using System.Runtime.Serialization;


namespace ExpensesCore.CustomException
{
    public class UsernameAlreadyExistException : Exception
    {
        public UsernameAlreadyExistException()
        {
        }

        public UsernameAlreadyExistException(string? message) : base(message)
        {
        }

        public UsernameAlreadyExistException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UsernameAlreadyExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
