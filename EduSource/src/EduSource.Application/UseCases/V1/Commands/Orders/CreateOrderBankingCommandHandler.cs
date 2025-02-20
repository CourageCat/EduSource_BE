using EduSource.Contract.Abstractions.Message;
using EduSource.Contract.Abstractions.Services;
using EduSource.Contract.Abstractions.Shared;
using EduSource.Contract.DTOs.PaymentDTOs;
using EduSource.Contract.Services.Orders;
using EduSource.Contract.Settings;
using EduSource.Domain.Abstraction.Dappers;
using EduSource.Domain.Abstraction.EntitiyFramework;
using EduSource.Domain.Exceptions;
using Microsoft.Extensions.Options;
namespace EduSource.Application.UseCases.V1.Commands.Orders;

public sealed class CreateOrderBankingCommandHandler : ICommandHandler<Command.CreateOrderBankingCommand>
{
    private readonly IPaymentService _paymentService;
    private readonly PayOSSetting _payOSSetting;
    private readonly IResponseCacheService _responseCacheService;
    private readonly IEFUnitOfWork _efUnitOfWork;
    private readonly IDPUnitOfWork _dpUnitOfWork;

    public CreateOrderBankingCommandHandler(IPaymentService paymentService, IOptions<PayOSSetting> payOSConfiguration, IResponseCacheService responseCacheService, IEFUnitOfWork efUnitOfWork, IDPUnitOfWork dPUnitOfWork)
    {
        _paymentService = paymentService;
        _payOSSetting = payOSConfiguration.Value;
        _responseCacheService = responseCacheService;
        _efUnitOfWork = efUnitOfWork;
        _dpUnitOfWork = dPUnitOfWork;
    }

    public async Task<Result> Handle(Command.CreateOrderBankingCommand request, CancellationToken cancellationToken)
    {
        //CreateOrderBankingCommandHandler
        var accountFound = await _efUnitOfWork.AccountRepository.FindByIdAsync(request.AccountId) ?? throw new AccountException.AccountNotFoundException();
        var productsInCart = await _dpUnitOfWork.ProductRepositories.GetProductsInCartToCheckoutAsync(request.AccountId);
        if (productsInCart.ToList().Count == 0)
        {
            throw new CartException.CheckoutWithNoProductsInCartException();
        }

        long orderId = new Random().Next(1, 100000);

        // Create payment dto
        List<ItemDTO> itemDTOs = new();
        productsInCart.ToList().ForEach(product =>
        {
            itemDTOs.Add(new ItemDTO(product.Name, 1, product.Price));
        });
        var createPaymentDto = new CreatePaymentDTO(orderId, $"Cart Checkout", itemDTOs, _payOSSetting.ErrorUrl, _payOSSetting.SuccessUrl + $"?orderId={orderId}");
        var result = await _paymentService.CreatePaymentLink(createPaymentDto);
        var resultForCache = new ResultCacheDTO(result.OrderCode, request.AccountId);
        // Save memory to when success or fail will know value
        await _responseCacheService.SetCacheResponseAsync($"order_{orderId}", resultForCache, TimeSpan.FromMinutes(60));
        
        return Result.Success(new Success<CreatePaymentResponseDTO>("", "", result));
    }
}
