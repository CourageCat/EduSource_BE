using Microsoft.Extensions.Configuration;
using EduSource.Contract.Abstractions.Services;
using EduSource.Contract.Enumarations.Authentication;
using EduSource.Domain.Entities;
using EduSource.Persistence;
using EduSource.Contract.Enumarations.Book;

namespace EduSource.Persistence.SeedData;

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

        if (!context.Books.Any())
        {
            context.Books.AddRange(
                Book.CreateBookForSeedData("I Learn Smart Start 1", "I-Learn-Smart-Start-1", "https://res.cloudinary.com/dc4eascme/image/upload/v1736586096/edusource/I-Learn-Smart-Start-1.jpg", 1, CategoryType.ILearnSmartStart), 
                Book.CreateBookForSeedData("I Learn Smart Start 2", "I-Learn-Smart-Start-2", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583438/edusource/I-Learn-Smart-Start-2.jpg", 2, CategoryType.ILearnSmartStart),
                Book.CreateBookForSeedData("I Learn Smart Start 3", "I-Learn-Smart-Start-3", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583439/edusource/I-Learn-Smart-Start-3.png", 3, CategoryType.ILearnSmartStart),
                Book.CreateBookForSeedData("I Learn Smart Start 4", "I-Learn-Smart-Start-4", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583438/edusource/I-Learn-Smart-Start-4.jpg", 4, CategoryType.ILearnSmartStart),
                Book.CreateBookForSeedData("I Learn Smart Start 5", "I-Learn-Smart-Start-5", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583438/edusource/I-Learn-Smart-Start-5.jpg", 5, CategoryType.ILearnSmartStart),
                Book.CreateBookForSeedData("Family and Friends 1", "Family-And-Friends-1", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583455/edusource/Family-And-Friends-1.png", 1, CategoryType.FamilyAndFriends),
                Book.CreateBookForSeedData("Family and Friends 2", "Family-And-Friends-2", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583455/edusource/Family-And-Friends-2.png", 2, CategoryType.FamilyAndFriends),
                Book.CreateBookForSeedData("Family and Friends 3", "Family-And-Friends-3", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583455/edusource/Family-And-Friends-3.png", 3, CategoryType.FamilyAndFriends),
                Book.CreateBookForSeedData("Family and Friends 4", "Family-And-Friends-4", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583456/edusource/Family-And-Friends-4.png", 4, CategoryType.FamilyAndFriends),
                Book.CreateBookForSeedData("Family and Friends 5", "Family-And-Friends-5", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583454/edusource/Family-And-Friends-5.jpg", 5, CategoryType.FamilyAndFriends),
                Book.CreateBookForSeedData("Global Success 1", "Global-Success-1", "https://res.cloudinary.com/dc4eascme/image/upload/v1736587391/edusource/Global-Success-1.jpg", 1, CategoryType.GlobalSuccess),
                Book.CreateBookForSeedData("Global Success 2", "Global-Success-2", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583472/edusource/Global-Success-2.jpg", 2, CategoryType.GlobalSuccess),
                Book.CreateBookForSeedData("Global Success 3", "Global-Success-3", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583470/edusource/Global-Success-3.jpg", 3, CategoryType.GlobalSuccess),
                Book.CreateBookForSeedData("Global Success 4", "Global-Success-4", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583471/edusource/Global-Success-4.jpg", 4, CategoryType.GlobalSuccess),
                Book.CreateBookForSeedData("Global Success 5", "Global-Success-5", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583474/edusource/Global-Success-5.webp", 5, CategoryType.GlobalSuccess)
            );
        }
        context.SaveChanges();
    }
}
