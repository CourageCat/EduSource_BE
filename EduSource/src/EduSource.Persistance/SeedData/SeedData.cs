using Microsoft.Extensions.Configuration;
using EduSource.Contract.Abstractions.Services;
using EduSource.Contract.Enumarations.Authentication;
using EduSource.Domain.Entities;
using EduSource.Persistence;

namespace Neighbor.Persistence.SeedData;

public static class SeedData
{
    public static void Seed(ApplicationDbContext context, IConfiguration configuration, IPasswordHashService passwordHashService)
    {
        if (!context.Roles.Any())
        {
            context.Roles.AddRange(
                new Role
                {
                    Id = RoleType.Admin,
                    RoleName = "Admin",
                },
                new Role
                {
                    Id = RoleType.Member,
                    RoleName = "Member"
                }
            );
        }
        context.SaveChanges();
    }
}
