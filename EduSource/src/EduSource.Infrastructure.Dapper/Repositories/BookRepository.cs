using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using EduSource.Domain.Abstraction.Dappers.Repositories;
using EduSource.Domain.Entities;

namespace EduSource.Infrastructure.Dapper.Repositories;
public class BookRepository : IBookRepositry
{
    private readonly IConfiguration _configuration;
    public BookRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Task<int> AddAsync(Book entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(Book entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(Book entity)
    {
        throw new NotImplementedException();
    }

    Task<IReadOnlyCollection<Book>> IGenericRepository<Book>.GetAllAsync()
    {
        throw new NotImplementedException();
    }

    Task<Book>? IGenericRepository<Book>.GetByIdAsync(Guid Id)
    {
        throw new NotImplementedException();
    }
}
