using Dapper;
using EduSource.Domain.Abstraction.Dappers.Repositories;
using EduSource.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System.Text;

namespace EduSource.Infrastructure.Dapper.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly IConfiguration _configuration;
    public OrderRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Task<int> AddAsync(Order entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(Order entity)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<Order>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Order>> GetAllOrdersByUserAsync(Guid accountId)
    {
        using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionStrings")))
        {
            // Valid columns for selecting
            var validColumns = new HashSet<string> { "Id"};

            // If no selected columns, select all
            var selectedColumnsString = string.Join(", ", validColumns); ;

            // Start building the query
            var queryBuilder = new StringBuilder(
                $@"SELECT {selectedColumnsString} FROM Orders
                WHERE 1=1 AND IsDeleted = 0 AND AccountId = @AccountId
            ");

            var parameters = new DynamicParameters();

            parameters.Add("AccountId", $"{accountId}");

            var items = (await connection.QueryAsync<Order>(queryBuilder.ToString(), parameters)).ToList();

            return items;
        }
    }

    public Task<Order>? GetByIdAsync(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(Order entity)
    {
        throw new NotImplementedException();
    }
}
