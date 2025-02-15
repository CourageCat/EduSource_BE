using FluentValidation;
using EduSource.Contract.Services.Orders;

namespace EduSource.Contract.Services.Orders.Validators;

internal class CreateOrderBankingValidator : AbstractValidator<Command.CreateOrderBankingCommand>
{
    public CreateOrderBankingValidator()
    {
        RuleFor(x => x.AccountId).NotNull().NotEmpty();
    }
}
