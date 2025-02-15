using EduSource.Contract.Abstractions.Message;
using EduSource.Contract.Abstractions.Shared;

namespace EduSource.Contract.Services.Orders;
public static class Command
{
    public record CreateOrderBankingCommand(Guid AccountId) : ICommand;
    public record OrderSuccessCommand(long OrderId) : ICommand<Success<Response.OrderSuccess>>;
    public record OrderFailCommand(long OrderId) : ICommand<Success<Response.OrderFail>>;
}

