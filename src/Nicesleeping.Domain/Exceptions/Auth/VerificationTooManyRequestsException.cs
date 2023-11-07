namespace Nicesleeping.Domain.Exceptions.Auth;

public class VerificationTooManyRequestsException : TooManyRequestException
{
    VerificationTooManyRequestsException()
    {
        TitleMessage = "You tried more than limits!";
    }
}
