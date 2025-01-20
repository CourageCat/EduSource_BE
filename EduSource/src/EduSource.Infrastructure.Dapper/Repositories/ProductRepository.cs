using Dapper;
using EduSource.Contract.Abstractions.Shared;
using EduSource.Contract.Services.Products;
using EduSource.Domain.Abstraction.Dappers.Repositories;
using EduSource.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace EduSource.Infrastructure.Dapper.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IConfiguration _configuration;
    public ProductRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Task<int> AddAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product>? GetByIdAsync(Guid Id)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedResult<Product>> GetPagedAsync(int pageIndex, int pageSize, Filter.ProductFilter filterParams, string[] selectedColumns)
    {
        using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionStrings")))
        {
            // Valid columns for selecting
            var validColumns = new HashSet<string> { "Id", "Name", "Category", "Unit", "ContentType", "UploadType", "TotalPage", "Size", "ImageUrl", "FileUrl", "Rating", "IsPublic", "IsApproved" };
            var columns = selectedColumns?.Where(c => validColumns.Contains(c)).ToArray();

            // If no selected columns, select all
            var selectedColumnsString = columns?.Length > 0 ? string.Join(", ", columns) : "*";

            // Start building the query
            var queryBuilder = new StringBuilder($"SELECT {selectedColumnsString} FROM Products WHERE 1=1 AND IsDeleted = 0");

            var parameters = new DynamicParameters();

            pageIndex = pageIndex <= 0 ? 1 : pageIndex;
            pageSize = pageSize <= 0 ? 10 : pageSize > 100 ? 100 : pageSize;

            var totalCountQuery = new StringBuilder($@"
        SELECT COUNT(1) 
        FROM Products p
        WHERE 1=1 AND IsDeleted = 0");

            // Filter by Name
            if (!string.IsNullOrEmpty(filterParams?.Name))
            {
                queryBuilder.Append(" AND Name LIKE @Name");
                totalCountQuery.Append(" AND Name LIKE @Name");
                parameters.Add("Name", $"%{filterParams.Name}%");
            }

            //Filter by Price
            if (filterParams?.Price.HasValue == true)
            {
                queryBuilder.Append(" AND Price = @Price");
                totalCountQuery.Append(" AND Price = @Price");
                parameters.Add("Price", $"{filterParams.Price}");
            }

            //Filter by Category
            if (filterParams?.Category.HasValue == true)
            {
                queryBuilder.Append(" AND Category = @Category");
                totalCountQuery.Append(" AND Category = @Category");
                parameters.Add("Category", $"{(int)filterParams.Category}");
            }

            //Filter by Description
            if (!string.IsNullOrEmpty(filterParams?.Description))
            {
                queryBuilder.Append(" AND Description LIKE @Description");
                totalCountQuery.Append(" AND Description LIKE @Description");
                parameters.Add("Description", $"%{filterParams.Description}%");
            }

            //Filter by ContentType
            if (filterParams?.ContentType.HasValue == true)
            {
                queryBuilder.Append(" AND ContentType = @ContentType");
                totalCountQuery.Append(" AND ContentType = @ContentType");
                parameters.Add("ContentType", $"{(int)filterParams.ContentType}");
            }

            //Filter by Unit
            if (filterParams?.Unit.HasValue == true)
            {
                queryBuilder.Append(" AND Unit = @Unit");
                totalCountQuery.Append(" AND Unit = @Unit");
                parameters.Add("Unit", $"{filterParams.Unit}");
            }

            //Filter by UploadType
            if (filterParams?.UploadType.HasValue == true)
            {
                queryBuilder.Append(" AND UploadType = @UploadType");
                totalCountQuery.Append(" AND UploadType = @UploadType");
                parameters.Add("UploadType", $"{(int)filterParams.UploadType}");
            }

            //Filter by TotalPage
            if (filterParams?.TotalPage.HasValue == true)
            {
                queryBuilder.Append(" AND TotalPage = @TotalPage");
                totalCountQuery.Append(" AND TotalPage = @TotalPage");
                parameters.Add("TotalPage", $"{filterParams.TotalPage}");
            }

            //Filter by Size
            if (filterParams?.Size.HasValue == true)
            {
                queryBuilder.Append(" AND Size = @Size");
                totalCountQuery.Append(" AND Size = @Size");
                parameters.Add("Size", $"{filterParams.Size}");
            }

            //Filter by Rating
            if (filterParams?.Rating.HasValue == true)
            {
                queryBuilder.Append(" AND Rating = @Rating");
                totalCountQuery.Append(" AND Rating = @Rating");
                parameters.Add("Rating", $"{filterParams.Rating}");
            }

            //Filter by IsPublic
            if (filterParams?.IsPublic.HasValue == true)
            {
                queryBuilder.Append(" AND IsPublic = @IsPublic");
                totalCountQuery.Append(" AND IsPublic = @IsPublic");
                parameters.Add("IsPublic", $"{filterParams.IsPublic}");
            }

            //Filter by IsApproved
            if (filterParams?.IsApproved.HasValue == true)
            {
                queryBuilder.Append(" AND IsApproved = @IsApproved");
                totalCountQuery.Append(" AND IsApproved = @IsApproved");
                parameters.Add("IsApproved", $"{filterParams.IsApproved}");
            }

            //Filter by BookId
            if (filterParams?.BookId.HasValue == true)
            {
                queryBuilder.Append(" AND BookId = @BookId");
                totalCountQuery.Append(" AND BookId = @BookId");
                parameters.Add("BookId", $"{filterParams.BookId}");
            }

            //Filter by StaffId
            if (filterParams?.StaffId.HasValue == true)
            {
                queryBuilder.Append(" AND AccountId = @StaffId");
                totalCountQuery.Append(" AND AccountId = @StaffId");
                parameters.Add("StaffId", $"{filterParams.StaffId}");
            }

            //Count TotalCount
            var totalCount = await connection.ExecuteScalarAsync<int>(totalCountQuery.ToString(), parameters);

            //Count TotalPages
            var totalPages = Math.Ceiling((totalCount / (double)pageSize));

            var offset = (pageIndex - 1) * pageSize;
            var paginatedQuery = $"{queryBuilder} ORDER BY Id OFFSET {offset} ROWS FETCH NEXT {pageSize} ROWS ONLY";

            var items = (await connection.QueryAsync<Product>(paginatedQuery, parameters)).ToList();

            return new PagedResult<Product>(items, pageIndex, pageSize, totalCount, totalPages);

        }
    }

    public Task<int> UpdateAsync(Product entity)
    {
        throw new NotImplementedException();
    }
}
