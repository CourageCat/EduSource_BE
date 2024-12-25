using EduSource.Domain.Abstraction.Dappers;
using EduSource.Domain.Abstraction.Dappers.Repositories;
using EduSource.Domain.Abstraction.Dappers.Repositories;

namespace EduSource.Infrastructure.Dapper;
public class DPUnitOfWork : IDPUnitOfWork
{
    public DPUnitOfWork(IAccountRepository accountRepository)
    {
        AccountRepositories = accountRepository;
    }
    public IAccountRepository AccountRepositories { get; }
}
