namespace rocket_landing.Core.Exceptions;

public class InvalidPlatformExceptionException : Exception
{
    public InvalidPlatformExceptionException(string message) : base(message)
    {
    }
}