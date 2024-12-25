using Microsoft.Extensions.DependencyInjection;
using EduSource.Domain.Abstraction.Dappers;
using EduSource.Domain.Abstraction.Dappers.Repositories;
using EduSource.Infrastructure.Dapper.Repositories;
using EduSource.Infrastructure.Dapper;

namespace Neighbor.Infrastructure.Dapper.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructureDapper(this IServiceCollection services)
        => services.AddTransient<IDPUnitOfWork, DPUnitOfWork>()
                   .AddTransient<IAccountRepository, AccountRepository>();

}
