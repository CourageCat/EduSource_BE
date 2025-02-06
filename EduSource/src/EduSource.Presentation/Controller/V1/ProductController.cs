using Asp.Versioning;
using EduSource.Contract.Abstractions.Shared;
using EduSource.Contract.DTOs.ProductDTOs;
using EduSource.Contract.Services.Products;
using EduSource.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static EduSource.Contract.DTOs.ProductDTOs.ProductRequestDTO;
using static EduSource.Contract.Services.Products.Filter;

namespace EduSource.Presentation.Controller.V1;

[ApiVersion(1)]
public class ProductController : ApiController
{
    public ProductController(ISender sender) : base(sender)
    {
    }
    [HttpGet("get_all_products", Name = "GetAllProducts")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<Success>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Result<Error>))]
    public async Task<IActionResult> GetAllBooks([FromQuery] GetAllProductRequestDTO request,
    [FromQuery] int pageIndex = 1,
    [FromQuery] int pageSize = 10,
    [FromQuery] string[] selectedColumns = null)
    {
        var filterParams = new ProductFilter(request.Name, request.Price, request.Category, request.Description, request.ContentType, request.Unit, request.UploadType, request.TotalPage, request.Size, request.Rating, request.IsPublic, request.IsApproved, null, request.BookId, null);
        
        var result = await Sender.Send(new Query.GetAllProductsQuery(pageIndex, pageSize, filterParams, selectedColumns));
        if (result.IsFailure)
            return HandlerFailure(result);

        return Ok(result);
    }

    [HttpGet("get_product_by_id", Name = "GetProductById")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<Success>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Result<Error>))]
    public async Task<IActionResult> GetProductById([FromQuery] Query.GetProductByIdQuery Queries)
    {
        var result = await Sender.Send(Queries);
        if (result.IsFailure)
            return HandlerFailure(result);

        return Ok(result);
    }
}
