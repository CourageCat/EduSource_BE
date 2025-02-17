using EduSource.Contract.Abstractions.Shared;
using EduSource.Domain.Abstraction.Dappers.Repositories;
using EduSource.Domain.Abstraction.EntitiyFramework.Repositories;
using EduSource.Domain.Entities;
using static EduSource.Contract.Services.Products.Filter;

namespace EduSource.Domain.Abstraction.Dappers.Repositories;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<PagedResult<Product>> GetPagedAsync(int pageIndex, int pageSize, ProductFilter filterParams, string[] selectedColumns);

    Task<PagedResult<Product>> GetProductsInCartAsync(int pageIndex, int pageSize, ProductFilter filterParams, string[] selectedColumns);

    Task<PagedResult<Product>> GetProductsPurchasedAsync(int pageIndex, int pageSize, ProductFilter filterParams, string[] selectedColumns);

    Task<IEnumerable<Product>> GetProductsInCartToCheckoutAsync(Guid accountId);


    Task<Product> GetDetailsAsync(Guid productId);

}
