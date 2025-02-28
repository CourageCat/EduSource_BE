using FluentValidation;

namespace EduSource.Contract.Services.Orders.Validators;

public class GetDashboardValidator : AbstractValidator<Query.GetDashboardQuery>
{
    public GetDashboardValidator()
    {
        RuleFor(x => x.year).NotNull().NotEmpty();
        RuleFor(x => x.month).NotNull().NotEmpty();
        RuleFor(x => x.week).NotNull().NotEmpty();
    }
}
