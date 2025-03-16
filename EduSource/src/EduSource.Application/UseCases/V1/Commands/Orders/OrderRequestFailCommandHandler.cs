using EduSource.Contract.Abstractions.Message;
using EduSource.Contract.Abstractions.Services;
using EduSource.Contract.Abstractions.Shared;
using EduSource.Contract.Services.Orders;
using EduSource.Contract.Settings;
using Microsoft.Extensions.Options;
namespace EduSource.Application.UseCases.V1.Commands.Orders;

public sealed class OrderRequestFailCommandHandler : ICommandHandler<Command.OrderRequestFailCommand, Success<Response.OrderRequestFail>>
{
    private readonly IResponseCacheService _responseCacheService;
    private readonly ClientSetting _clientSetting;

    public OrderRequestFailCommandHandler
        (IResponseCacheService responseCachService,
        IOptions<ClientSetting> clientConfiguration)
    {
        _responseCacheService = responseCachService;
        _clientSetting = clientConfiguration.Value;
    }

    public async Task<Result<Success<Response.OrderRequestFail>>> Handle(Command.OrderRequestFailCommand request, CancellationToken cancellationToken)
    {
        // Delete cache order
        await _responseCacheService.DeleteCacheResponseAsync($"order_{request.OrderId}");
        var result = new Response.OrderRequestFail($"{_clientSetting.Url}{_clientSetting.OrderRequestFail}/fail");
        return Result.Success(new Success<Response.OrderRequestFail>("", "", result));
    }
}
