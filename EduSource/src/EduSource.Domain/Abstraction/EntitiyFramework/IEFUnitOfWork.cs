using EduSource.Domain.Abstraction.EntitiyFramework.Repositories;

namespace EduSource.Domain.Abstraction.EntitiyFramework;

public interface IEFUnitOfWork : IAsyncDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    IAccountRepository AccountRepository { get; }
}
