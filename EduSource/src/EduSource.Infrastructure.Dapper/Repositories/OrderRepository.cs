using Dapper;
using EduSource.Contract.Abstractions.Shared;
using EduSource.Contract.Enumarations.Order;
using EduSource.Domain.Abstraction.Dappers.Repositories;
using EduSource.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System.Text;
using static EduSource.Contract.Services.Orders.Filter;
using static EduSource.Contract.Services.Products.Filter;

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

    public async Task<PagedResult<Order>> GetAllOrdersByAdminAsync(int pageIndex, int pageSize, OrderFilter filterParams, string[] selectedColumns)
    {
        using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionStrings")))
        {
            // Valid columns for selecting
            var validColumns = new HashSet<string> { "o.Id", "o.TotalPrice", "o.OrderCode", "o.Description", "o.CreatedDate", "o.ModifiedDate AS OrderModifiedDate", "a.Id", "a.FirstName", "a.LastName", "a.Email", "a.CropAvatarUrl", "a.GenderType", "a.CreatedDate AS AccountCreatedDate", "od.Id", "od.Quantity", "od.CreatedDate AS OrderDetailsCreatedDate", "p.Id", "p.Name", "p.Price" };
            var columns = selectedColumns?.Where(c => validColumns.Contains(c)).ToArray();

            // If no selected columns, select all
            var selectedColumnsString = columns?.Length > 0 ? string.Join(", ", columns) : string.Join(", ", validColumns); ;

            // Start building the query
            var queryBuilder = new StringBuilder(
                $@"SELECT {selectedColumnsString} FROM Orders o 
                JOIN Accounts a ON a.Id = o.AccountId
                JOIN OrderDetails od ON o.Id = od.OrderId
                JOIN Products p ON p.Id = od.ProductId                
                WHERE 1=1 AND p.IsDeleted = 0");

            var parameters = new DynamicParameters();

            pageIndex = pageIndex <= 0 ? 1 : pageIndex;
            pageSize = pageSize <= 0 ? 10 : pageSize > 100 ? 100 : pageSize;

            // Filter by Description
            if (!string.IsNullOrEmpty(filterParams?.Description))
            {
                queryBuilder.Append(" AND Description LIKE @Description");
                parameters.Add("Description", $"%{filterParams.Description}%");
            }

            //Filter by MinValue and MaxValue
            if (filterParams?.MinValue.HasValue == true && filterParams?.MaxValue.HasValue == true)
            {
                queryBuilder.Append(" AND Price >= @MinValue AND Price <= MaxValue");
                parameters.Add("MinValue", $"{filterParams.MinValue}");
                parameters.Add("MaxValue", $"{filterParams.MaxValue}");
            }

            // Query products and their orders
            var orderData = new Dictionary<Guid, Order>();

            await connection.QueryAsync<Order, Account, OrderDetails, Product, Order>(
                queryBuilder.ToString(),
                (order, account, orderDetails, product) =>
                {
                    if (!orderData.TryGetValue(order.Id, out var existingOrder))
                    {
                        // If this order is not yet added, create it
                        existingOrder = order;
                        existingOrder.UpdateOrderDetails(new List<OrderDetails>());
                        orderData.Add(existingOrder.Id, existingOrder);
                    }
                    existingOrder.UpdateAccount(account);
                    // Add orderDetails to the order object
                    if (orderDetails != null && !existingOrder.OrderDetails.Any(od => od.Id == orderDetails.Id))
                    {
                        orderDetails.UpdateProduct(product);
                        //if (product.Id == orderDetails.ProductId)
                        //{
                        existingOrder.OrderDetails.Add(orderDetails);
                        //}

                    }
                    return existingOrder;
                },
                parameters,
                splitOn: "OrderModifiedDate, AccountCreatedDate, OrderDetailsCreatedDate");
            //Result
            var result = orderData.Values.ToList();
            // Count TotalCount, TotalPages and calculate offset
            int totalCount = result.Count;
            var totalPages = Math.Ceiling((totalCount / (double)pageSize));
            var offset = (pageIndex - 1) * pageSize;

            // Apply sorting
            if (filterParams.SortType == SortType.PaidDate)
            {
                result = filterParams.IsSortASC == null
                    ? result.OrderByDescending(o => o.TotalPrice).Reverse().ToList()
                    : filterParams.IsSortASC == true
                        ? result.OrderByDescending(o => o.TotalPrice).Reverse().ToList()
                        : result.OrderByDescending(o => o.TotalPrice).ToList();
            }
            else if (filterParams.SortType == SortType.PaidDate)
            {
                result = filterParams.IsSortASC == null
                    ? result.OrderByDescending(o => o.CreatedDate).Reverse().ToList()
                    : filterParams.IsSortASC == true
                        ? result.OrderByDescending(o => o.TotalPrice).Reverse().ToList()
                        : result.OrderByDescending(o => o.TotalPrice).ToList();
            }
            else
            {
                result = result.OrderByDescending(o => o.Id).Reverse().ToList();
            }
            // Apply pagination
            result = result.Skip(offset).Take(pageSize).ToList();

            return new PagedResult<Order>(result, pageIndex, pageSize, totalCount, totalPages);
        }
    }

    public async Task<IEnumerable<Order>> GetAllOrdersByUserAsync(Guid accountId)
    {
        using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionStrings")))
        {
            // Valid columns for selecting
            var validColumns = new HashSet<string> { "Id" };

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
