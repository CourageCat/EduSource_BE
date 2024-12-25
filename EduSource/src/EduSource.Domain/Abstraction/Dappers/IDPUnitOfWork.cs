using EduSource.Domain.Abstraction.Dappers.Repositories;
using EduSource.Domain.Abstraction.Dappers.Repositories;

namespace EduSource.Domain.Abstraction.Dappers;

public interface IDPUnitOfWork
{
    IAccountRepository AccountRepositories { get; }
}
