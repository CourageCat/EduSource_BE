using Asp.Versioning;
using EduSource.Contract.Abstractions.Shared;
using EduSource.Contract.Services.Authentications;
using EduSource.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduSource.Presentation.Controller.V1;

[ApiVersion(1)]
public class RoleController : ApiController
{
    public RoleController(ISender sender) : base(sender)
    { }

    [HttpPut("handle_user", Name = "HandleUser")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<Success>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Result<Error>))]
    public async Task<IActionResult> HandleUser()
    {
        var result = await Sender.Send(new Query.LoginQuery("",""));
        if (result.IsFailure)
            return HandlerFailure(result);

        return Ok(result);
    }
}