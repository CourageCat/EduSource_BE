using EduSource.Contract.Enumarations.Book;
using EduSource.Domain.Abstraction.Entities;

namespace EduSource.Domain.Entities;

public class Book : DomainEntity<Guid>
{
    public Book()
    {

    }

    public string Name { get; private set; }
    public string ImageId { get; private set; }
    public string ImageUrl { get; private set; }
    public int GradeLevel { get; private set; }
    public CategoryType Category {  get; private set; } 
    public virtual ICollection<Product> Products { get; private set; }
}
