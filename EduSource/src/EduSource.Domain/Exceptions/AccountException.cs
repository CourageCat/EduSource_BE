using EduSource.Contract.Enumarations.MessagesList;

namespace EduSource.Domain.Exceptions;

public static class AccountException
{
    public sealed class AccountNotFoundException : NotFoundException
    {
        public AccountNotFoundException()
            : base(MessagesList.AccountNotFoundException.GetMessage().Message,
                   MessagesList.AccountNotFoundException.GetMessage().Code)
        { }


    }
}
