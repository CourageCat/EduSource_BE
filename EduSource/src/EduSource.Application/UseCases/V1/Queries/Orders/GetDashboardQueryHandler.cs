using EduSource.Contract.Abstractions.Message;
using EduSource.Contract.Abstractions.Shared;
using EduSource.Contract.Enumarations.MessagesList;
using EduSource.Contract.Services.Orders;
using EduSource.Domain.Abstraction.Dappers;
using MediatR;
using System.Threading.Tasks.Dataflow;
using static EduSource.Contract.DTOs.OrderDTOs.DashboardDTO;

namespace EduSource.Application.UseCases.V1.Queries.Orders;

public sealed class GetDashboardQueryHandler : IQueryHandler<Query.GetDashboardQuery, Success<Response.DashboardResponse>>
{
    private readonly IDPUnitOfWork _dpUnitOfWork;

    public GetDashboardQueryHandler(IDPUnitOfWork dpUnitOfWork)
    {
        _dpUnitOfWork = dpUnitOfWork;
    }

    async Task<Result<Success<Response.DashboardResponse>>> IRequestHandler<Query.GetDashboardQuery, Result<Success<Response.DashboardResponse>>>.Handle(Query.GetDashboardQuery request, CancellationToken cancellationToken)
    {
        var customersCount = await _dpUnitOfWork.AccountRepositories.CountAllUsers();
        var ordersCount = await _dpUnitOfWork.OrderRepositories.CountAllOrders();
        var totalMoneyOfOrdersInMonth = await _dpUnitOfWork.OrderRepositories.GetTotalMoneyOfOrdersInMonth(request.month, request.year);
        var totalMoneyOfOrdersToday = await _dpUnitOfWork.OrderRepositories.GetTotalMoneyOfOrdersInDay(DateTime.Now);
        double target = 6000000;
        double progress = Math.Round((totalMoneyOfOrdersInMonth / target * 100) * 100.0) / 100.0;
        double growthPercentage = Math.Round((totalMoneyOfOrdersToday / target * 100) * 100.0) / 100.0;
        var monthlyTarget = new MonthlyTargetDTO()
        {
            Progress = progress,
            Target = target,
            Revenue = totalMoneyOfOrdersInMonth,
            TodayRevenue = totalMoneyOfOrdersToday,
            GrowthPercentage = growthPercentage,
            Currency = "VNĐ",
            Comparison = "up"
        };
        List<DateTime> dates = new List<DateTime>();
        int day = 1 + (request.week - 1) * 7;
        for (int i = 0; i < 7; i++)
        {
            try
            {
                var date = new DateTime(request.year, request.month, day + i);
                dates.Add(date);
            }
            catch (Exception ex)
            {
            }
        }
        var listRevenueInWeek = await _dpUnitOfWork.OrderRepositories.GetRevenueInListDates(dates);
        var categories = new List<string>();
        var series = new List<SeriesDTO>
        {
            new SeriesDTO
            {
                Name = "Revenue",
                Data = listRevenueInWeek.Values.ToList(),
            }
        };
        listRevenueInWeek.ToList().ForEach(revenue =>
        {
            var category = $"{revenue.Key.Day}/{revenue.Key.Month}/{revenue.Key.Year}";
            categories.Add(category);
        });
        var data = new DataDTO()
        {
            Categories = categories,
            Series = series
        };
        var result = new Response.DashboardResponse(data, monthlyTarget, customersCount, ordersCount);

        return Result.Success(new Success<Response.DashboardResponse>(MessagesList.OrderGetDashboardSuccess.GetMessage().Message, MessagesList.OrderGetDashboardSuccess.GetMessage().Code, result));
    }
}
