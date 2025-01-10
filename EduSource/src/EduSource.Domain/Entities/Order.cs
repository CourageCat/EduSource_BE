using EduSource.Domain.Abstraction.Entities;

namespace EduSource.Domain.Entities;

public class Order : DomainEntity<Guid>
{
    public Order()
    {

    }

    public double TotalPrice { get; private set; }
    public Guid AccountId { get; private set; }
    public virtual Account Account { get; private set; }
    public virtual ICollection<OrderDetails> OrderDetails { get; private set; }
}
