using EduSource.Domain.Abstraction.Entities;

namespace EduSource.Domain.Entities;

public class OrderDetails : DomainEntity<Guid>
{
    public OrderDetails()
    {

    }

    public int Quantity { get; private set; }
    public Guid? OrderId { get; private set; }
    public virtual Order? Order { get; private set; }
    public Guid ComboId { get; private set; }
    public virtual Combo Combo { get; private set; }
    public Guid? ProductId { get; private set; }
    public virtual Product? Product { get; private set; }
}
