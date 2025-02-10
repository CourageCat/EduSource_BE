using EduSource.Contract.Abstractions.Message;
using EduSource.Contract.Abstractions.Shared;
using EduSource.Contract.Enumarations.MessagesList;
using EduSource.Contract.Services.Products;
using EduSource.Domain.Abstraction.Dappers;
using EduSource.Domain.Exceptions;
using static EduSource.Contract.DTOs.ProductDTOs.ProductResponseDTO;
using static EduSource.Contract.Services.Products.Response;

namespace EduSource.Application.UseCases.V1.Queries.Products;

public sealed class GetProductByIdQueryHandler : IQueryHandler<Query.GetProductByIdQuery, Success<ProductResponse>>
{
    private readonly IDPUnitOfWork _dpUnitOfWork;

    public GetProductByIdQueryHandler(IDPUnitOfWork dpUnitOfWork)
    {
        _dpUnitOfWork = dpUnitOfWork;
    }

    public async Task<Result<Success<ProductResponse>>> Handle(Query.GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        //Find Product By Id
        var productFound = await _dpUnitOfWork.ProductRepositories.GetDetailsAsync(request.Id);
        if (productFound == null)
        {
            throw new ProductException.ProductNotFoundException();
        }
        var result = new ProductResponse(productFound.Id, productFound.Name, productFound.Price, productFound.Category, productFound.Unit, productFound.Description, productFound.ContentType, productFound.UploadType, productFound.TotalPage, productFound.Size, productFound.ImageUrl, productFound.FileUrl, productFound.Rating, productFound.IsPublic, productFound.IsApproved, productFound.ImageOfProducts.ToList().Select(x => x.ImageUrl).ToList(), new BookResponse()
        {
            Name = productFound.Book.Name,
            Category = productFound.Book.Category,
            ImageUrl = productFound.Book.ImageUrl,
            GradeLevel = productFound.Book.GradeLevel,
        });
        return Result.Success(new Success<ProductResponse>(MessagesList.ProductGetDetailsProductsSuccess.GetMessage().Code, MessagesList.ProductGetDetailsProductsSuccess.GetMessage().Message, result));
    }
}
