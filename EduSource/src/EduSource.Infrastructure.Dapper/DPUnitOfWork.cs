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

    public IComboRepository ComboRepositories { get; }

    public IFeedbackRepository FeedbackRepositories { get; }

    public IImageOfProductRepository ImageOfProductRepositories { get; }

    public IOrderDetailsRepository OrderDetailsRepositories { get; }

    public IOrderRepository OrderRepositories { get; }

    public IProductInComboRepository ProductInComboRepositories { get; }

    public IProductRepository ProductRepositories { get; }

    public IWishlistRepository WishlistRepositories { get; }

    public ICartRepository CartRepositories { get; }

    public IBookRepositry BookRepositries { get; }
}
