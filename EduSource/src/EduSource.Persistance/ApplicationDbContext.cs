using Microsoft.EntityFrameworkCore;
using EduSource.Domain.Entities;

namespace EduSource.Persistence;
public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() { }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
        => builder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Role> Roles { get; set; }

}