using EduSource.Contract.Abstractions.Message;
using EduSource.Contract.Abstractions.Shared;
using static Neighbor.Contract.Services.Products.Filter;

namespace EduSource.Contract.Services.Books;

public static class Query
{
    public record GetAllBooksQuery(int PageIndex,
            int PageSize,
            BookFilter FilterParams,
            string[] SelectedColumns) : IQuery<Success<PagedResult<Response.BookResponse>>>;
}
