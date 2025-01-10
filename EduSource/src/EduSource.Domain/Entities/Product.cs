using EduSource.Contract.Enumarations.Product;
using EduSource.Domain.Abstraction.Entities;

namespace EduSource.Domain.Entities;

public class Product : DomainEntity<Guid>
{
    public Product()
    {

    }

    public string Name { get; private set; }
    public double Price { get; private set; }
    public CategoryType Category { get; private set; }
    public string Description { get; private set; }
    public int Unit {  get; private set; }
    public UploadType UploadType { get; private set; }
    public int TotalPage { get; private set; }
    public double Size { get; private set; }
    public string ImageId { get; private set; }
    public string ImageUrl { get; private set; }
    public string FileId { get; private set; }
    public string FileUrl { get; private set; }
    public double Rating { get; private set; }
    public bool IsPublic { get; private set; }
    public bool IsApproved { get; private set; }
    public Guid AccountId { get; private set; }
    public virtual Account Account { get; private set; }
    public Guid BookId { get; private set; }
    public virtual Book Book { get; private set; }
    public virtual ICollection<Wishlist> Wishlists { get; private set; }
    public virtual ICollection<OrderDetails> OrderDetails { get; private set; }
    public virtual ICollection<ProductInCombo> ProductInCombos { get; private set; }
    public virtual ICollection<ImageOfProduct> ImageOfProducts { get; private set; }
    public virtual ICollection<Feedback> Feedbacks { get; private set; }
}
