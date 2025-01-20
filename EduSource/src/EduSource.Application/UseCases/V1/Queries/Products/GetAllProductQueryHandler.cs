using AutoMapper;
using EduSource.Contract.Abstractions.Message;
using EduSource.Contract.Abstractions.Shared;
using EduSource.Contract.Enumarations.MessagesList;
using EduSource.Contract.Services.Products;
using EduSource.Domain.Abstraction.Dappers;
using System.Collections;
using static EduSource.Contract.Services.Books.Response;
using static EduSource.Contract.Services.Products.Response;

namespace EduSource.Application.UseCases.V1.Queries.Products;

public sealed class GetAllProductQueryHandler : IQueryHandler<Query.GetAllProductsQuery, Success<PagedResult<ProductResponse>>>
{
    private readonly IDPUnitOfWork _dpUnitOfWork;
    private readonly IMapper _mapper;

    public GetAllProductQueryHandler(IDPUnitOfWork dpUnitOfWork, IMapper mapper)
    {
        _dpUnitOfWork = dpUnitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<Success<PagedResult<ProductResponse>>>> Handle(Query.GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var listProducts = await _dpUnitOfWork.ProductRepositories.GetPagedAsync(request.PageIndex, request.PageSize, request.FilterParams, request.SelectedColumns);
        var listProductsMapped = new List<ProductResponse>();
        listProducts.Items.ForEach(product =>
        {
            listProductsMapped.Add(new ProductResponse(product.Id, product.Name, product.Category, product.Unit, product.Description, product.ContentType, product.UploadType, product.TotalPage, product.Size, product.ImageUrl, product.FileUrl, product.Rating, product.IsPublic, product.IsApproved, null));
        });
        //Mapping Category to CategoryResponse
        var result = new PagedResult<ProductResponse>(listProductsMapped, listProducts.PageIndex, listProducts.PageSize, listProducts.TotalCount, listProducts.TotalPages);
        //Check if ListCategory is empty
        if (listProducts.Items.Count == 0)
        {
            return Result.Success(new Success<PagedResult<ProductResponse>>(MessagesList.ProductNotFoundException.GetMessage().Code, MessagesList.ProductNotFoundException.GetMessage().Message, result));
        }
        //Return result
        return Result.Success(new Success<PagedResult<ProductResponse>>(MessagesList.ProductGetAllProductsSuccess.GetMessage().Code, MessagesList.ProductGetAllProductsSuccess.GetMessage().Message, result));
    }
}
