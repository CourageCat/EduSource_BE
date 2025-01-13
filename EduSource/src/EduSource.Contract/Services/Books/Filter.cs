using EduSource.Contract.Enumarations.Book;

namespace Neighbor.Contract.Services.Products;

public static class Filter
{
    public record BookFilter(Guid? Id, string? Name, int? GradeLevel, CategoryType? Category);
}