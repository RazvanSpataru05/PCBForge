namespace backend.backend.Exceptions
{
    public class InvalidCredentialsException : AppException
    {
        public InvalidCredentialsException(string message) : base(message) { }
    }
}
