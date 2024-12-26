using EduSource.Contract.Enumarations.MessagesList;
namespace EduSource.Domain.Exceptions;

public static class AuthenticationException
{
    public sealed class EmailExistException : BadRequestException
    {
        public EmailExistException()
            : base(MessagesList.AuthEmailExistException.GetMessage().Message,
                   MessagesList.AuthEmailExistException.GetMessage().Code)
        { }
    }

    public sealed class RegisterTimeOutException : BadRequestException
    {
        public RegisterTimeOutException()
            : base(MessagesList.AuthRegisterTimeOutException.GetMessage().Message,
                   MessagesList.AuthRegisterTimeOutException.GetMessage().Code)
        { }
    }
}
