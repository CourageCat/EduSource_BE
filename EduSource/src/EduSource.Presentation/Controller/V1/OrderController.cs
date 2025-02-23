using Asp.Versioning;
using EduSource.Contract.Abstractions.Shared;
using EduSource.Contract.Services.Orders;
using EduSource.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static EduSource.Contract.DTOs.OrderDTOs.GetAllOrdersDTO;
using static EduSource.Contract.Services.Orders.Filter;
using static EduSource.Contract.Services.Products.Filter;

namespace EduSource.Presentation.Controller.V1;

[ApiVersion(1)]
public class OrderController : ApiController
{
    public OrderController(ISender sender) : base(sender)
    { }

    [Authorize]
    [HttpPost("create_order", Name = "CreateOrder")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<Success>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Result<Error>))]
    public async Task<IActionResult> CreateOrder()
    {
        var userId = Guid.Parse(User.FindFirstValue("UserId"));
        var result = await Sender.Send(new Command.CreateOrderBankingCommand(userId));
        if (result.IsFailure)
            return HandlerFailure(result);

        return Ok(result);
    }

    [HttpGet("order_success", Name = "OrderSuccess")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> OrderSuccess([FromQuery] long orderId)
    {
        var result = await Sender.Send(new Command.OrderSuccessCommand(orderId));
        if (result.IsFailure)
            return HandlerFailure(result);

        return Redirect(result.Value.Data.Url);
    }

    [HttpGet("order_fail", Name = "OrderFail")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> OrderFail([FromQuery] long orderId)
    {
        var result = await Sender.Send(new Command.OrderFailCommand(orderId));
        if (result.IsFailure)
            return HandlerFailure(result);

        return Redirect(result.Value.Data.Url);
    }
    [Authorize(Policy = "AdminPolicy")]

    [HttpGet("get_all_orders", Name = "GetAllOrders")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<Success>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Result<Error>))]
    public async Task<IActionResult> GetAllOrders([FromQuery] GetAllOrdersRequestDTO request,
    [FromQuery] int pageIndex = 1,
    [FromQuery] int pageSize = 10,
    [FromQuery] string[] selectedColumns = null)
    {
        var filterParams = new OrderFilter(request.SortType, request.IsSortASC, request.MinValue, request.MaxValue, request.Description, null);

        var result = await Sender.Send(new Query.GetAllOrdersQuery(pageIndex, pageSize, filterParams, selectedColumns));
        if (result.IsFailure)
            return HandlerFailure(result);

        return Ok(result);
    }
}