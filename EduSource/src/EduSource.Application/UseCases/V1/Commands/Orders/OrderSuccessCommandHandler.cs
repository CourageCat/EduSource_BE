using EduSource.Contract.Abstractions.Message;
using EduSource.Contract.Abstractions.Services;
using EduSource.Contract.Abstractions.Shared;
using EduSource.Contract.DTOs.OrderDTOs;
using EduSource.Contract.Services.Orders;
using EduSource.Contract.Settings;
using EduSource.Domain.Abstraction.Dappers;
using EduSource.Domain.Abstraction.EntitiyFramework;
using EduSource.Domain.Entities;
using EduSource.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace EduSource.Application.UseCases.V1.Commands.Orders;

public sealed class OrderSuccessCommandHandler : ICommandHandler<Command.OrderSuccessCommand, Success<Response.OrderSuccess>>
{
    private readonly IEFUnitOfWork _efUnitOfWork;
    private readonly IDPUnitOfWork _dpUnitOfWork;
    private readonly IPublisher _publisher;
    private readonly IResponseCacheService _responseCacheService;
    private readonly ClientSetting _clientSetting;

    public OrderSuccessCommandHandler(IEFUnitOfWork efUnitOfWork, IDPUnitOfWork dPUnitOfWork, IPublisher publisher, IResponseCacheService responseCacheService, IOptions<ClientSetting> clientConfiguration)
    {
        _efUnitOfWork = efUnitOfWork;
        _dpUnitOfWork = dPUnitOfWork;
        _publisher = publisher;
        _responseCacheService = responseCacheService;
        _clientSetting = clientConfiguration.Value;
    }
    public async Task<Result<Success<Response.OrderSuccess>>> Handle(Command.OrderSuccessCommand request, CancellationToken cancellationToken)
    {
        // Get infomation saved in memory
        var orderMemory = await _responseCacheService.GetCacheResponseAsync($"order_{request.OrderId}");
        // Conver JSON to object
        var orderObject = JsonConvert.DeserializeObject<Command.CreateOrderBankingCommand>(orderMemory);


        // Find User
        var account = await _efUnitOfWork.AccountRepository.FindByIdAsync(orderObject.AccountId) ?? throw new AccountException.AccountNotFoundException();

        // Find Products in User's Cart
        var productsInCart = await _dpUnitOfWork.ProductRepositories.GetProductsInCartToCheckoutAsync(orderObject.AccountId);
        if (productsInCart.ToList().Count == 0)
        {
            throw new CartException.CheckoutWithNoProductsInCartException();
        }
        // Calculate the sum of order
        var sumOfOrder = productsInCart.Sum(p => p.Price);
        // Create Order
        var orderId = Guid.NewGuid();
        var orderCreated = Order.CreateOrder(orderId, sumOfOrder, orderObject.AccountId);
        _efUnitOfWork.OrderRepository.Add(orderCreated);
        // Create OrderDetails for Product of order
        var listOrderDetails = new List<OrderDetails>();
        productsInCart.ToList().ForEach(p =>
        {
            listOrderDetails.Add(OrderDetails.CreateOrderDetailsWithProduct(1, orderId, p.Id));
        });
        _efUnitOfWork.OrderDetailsRepository.AddRange(listOrderDetails);
        // Delete Products in Cart
        var cartItems = await _efUnitOfWork.CartRepository.FindAllAsync(x => x.AccountId == orderObject.AccountId);
        _efUnitOfWork.CartRepository.RemoveMultiple(cartItems.ToList());
        await _efUnitOfWork.SaveChangesAsync(cancellationToken);
        // Delete cache order
        await _responseCacheService.DeleteCacheResponseAsync($"order_{request.OrderId}");
        // Create List InvoiceItems for email
        var invoiceItems = new List<EmailOrderDTO>();
        productsInCart.ToList().ForEach(p =>
        {
            invoiceItems.Add(new EmailOrderDTO()
            {
                Description = p.Name,
                Price = p.Price,
                Quantity = 1,
                Total = p.Price
            });
        });
        // Send success order email and invoice for User
        await Task.WhenAll(
           _publisher.Publish(new DomainEvent.NotiUserOrderSuccess(orderCreated.Id, account.Email, orderId.ToString(), DateTime.UtcNow.ToString(), invoiceItems, sumOfOrder), cancellationToken)
        );
        var result = new Response.OrderSuccess($"{_clientSetting.Url}{_clientSetting.OrderSuccess}");
        return Result.Success(new Success<Response.OrderSuccess>("", "", result));
    }
}
