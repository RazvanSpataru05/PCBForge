namespace backend.backend.Exceptions
{
    public class EmailAlreadyExistsException : AppException
    {
        public EmailAlreadyExistsException(string message) : base(message) { }
    }
}
