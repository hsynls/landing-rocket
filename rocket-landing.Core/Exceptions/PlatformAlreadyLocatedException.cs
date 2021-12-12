namespace rocket_landing.Core.Exceptions;

public class PlatformAlreadyLocatedException : Exception
{
    public PlatformAlreadyLocatedException(string message) : base(message)
    {
    }
}