using Microsoft.Extensions.Configuration;
using EduSource.Contract.Abstractions.Services;
using EduSource.Contract.Enumarations.Authentication;
using EduSource.Domain.Entities;
using EduSource.Persistence;
using EduSource.Contract.Enumarations.Book;
using EduSource.Contract.Enumarations.Product;

namespace EduSource.Persistence.SeedData;

public static class SeedData
{
    public static void Seed(ApplicationDbContext context, IConfiguration configuration, IPasswordHashService passwordHashService)
    {
        Guid staffId = Guid.NewGuid();
        Guid ILearnSmartStart1 = Guid.NewGuid();
        Guid ILearnSmartStart2 = Guid.NewGuid();
        Guid ILearnSmartStart3 = Guid.NewGuid();
        Guid ILearnSmartStart4 = Guid.NewGuid();
        Guid ILearnSmartStart5 = Guid.NewGuid();
        Guid FamilyAndFriends1 = Guid.NewGuid();
        Guid FamilyAndFriends2 = Guid.NewGuid();
        Guid FamilyAndFriends3 = Guid.NewGuid();
        Guid FamilyAndFriends4 = Guid.NewGuid();
        Guid FamilyAndFriends5 = Guid.NewGuid();
        Guid GlobalSuccess1 = Guid.NewGuid();
        Guid GlobalSuccess2 = Guid.NewGuid();
        Guid GlobalSuccess3 = Guid.NewGuid();
        Guid GlobalSuccess4 = Guid.NewGuid();
        Guid GlobalSuccess5 = Guid.NewGuid();
        int numberOfProducts = 1;
        List<Guid> listProduct = new List<Guid>();
        for (int i = 0; i < numberOfProducts; i++)
        {
            listProduct.Add(Guid.NewGuid());
        }

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
                    Id = RoleType.Staff,
                    RoleName = "Staff",
                },
                new Role
                {
                    Id = RoleType.Member,
                    RoleName = "Member"
                }
            );
        }
        if (!context.Accounts.Any())
        {
            context.Accounts.AddRange(
                Account.CreateAdminAccount(configuration["AccountAdmin:Email"], passwordHashService.HashPassword(configuration["AccountAdmin:Password"])),
                Account.CreateStaffAssistant(staffId, configuration["AccountStaff:Email"], passwordHashService.HashPassword(configuration["AccountStaff:Password"]))
            );
        }

        if (!context.Books.Any())
        {
            context.Books.AddRange(
                Book.CreateBookForSeedData(ILearnSmartStart1, "I Learn Smart Start 1", "I-Learn-Smart-Start-1", "https://res.cloudinary.com/dc4eascme/image/upload/v1736586096/edusource/I-Learn-Smart-Start-1.jpg", 1, Contract.Enumarations.Book.CategoryType.ILearnSmartStart),
                Book.CreateBookForSeedData(ILearnSmartStart2, "I Learn Smart Start 2", "I-Learn-Smart-Start-2", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583438/edusource/I-Learn-Smart-Start-2.jpg", 2, Contract.Enumarations.Book.CategoryType.ILearnSmartStart),
                Book.CreateBookForSeedData(ILearnSmartStart3, "I Learn Smart Start 3", "I-Learn-Smart-Start-3", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583439/edusource/I-Learn-Smart-Start-3.png", 3, Contract.Enumarations.Book.CategoryType.ILearnSmartStart),
                Book.CreateBookForSeedData(ILearnSmartStart4, "I Learn Smart Start 4", "I-Learn-Smart-Start-4", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583438/edusource/I-Learn-Smart-Start-4.jpg", 4, Contract.Enumarations.Book.CategoryType.ILearnSmartStart),
                Book.CreateBookForSeedData(ILearnSmartStart5, "I Learn Smart Start 5", "I-Learn-Smart-Start-5", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583438/edusource/I-Learn-Smart-Start-5.jpg", 5, Contract.Enumarations.Book.CategoryType.ILearnSmartStart),
                Book.CreateBookForSeedData(FamilyAndFriends1, "Family and Friends 1", "Family-And-Friends-1", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583455/edusource/Family-And-Friends-1.png", 1, Contract.Enumarations.Book.CategoryType.FamilyAndFriends),
                Book.CreateBookForSeedData(FamilyAndFriends2, "Family and Friends 2", "Family-And-Friends-2", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583455/edusource/Family-And-Friends-2.png", 2, Contract.Enumarations.Book.CategoryType.FamilyAndFriends),
                Book.CreateBookForSeedData(FamilyAndFriends3, "Family and Friends 3", "Family-And-Friends-3", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583455/edusource/Family-And-Friends-3.png", 3, Contract.Enumarations.Book.CategoryType.FamilyAndFriends),
                Book.CreateBookForSeedData(FamilyAndFriends4, "Family and Friends 4", "Family-And-Friends-4", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583456/edusource/Family-And-Friends-4.png", 4, Contract.Enumarations.Book.CategoryType.FamilyAndFriends),
                Book.CreateBookForSeedData(FamilyAndFriends5, "Family and Friends 5", "Family-And-Friends-5", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583454/edusource/Family-And-Friends-5.jpg", 5, Contract.Enumarations.Book.CategoryType.FamilyAndFriends),
                Book.CreateBookForSeedData(GlobalSuccess1, "Global Success 1", "Global-Success-1", "https://res.cloudinary.com/dc4eascme/image/upload/v1736587391/edusource/Global-Success-1.jpg", 1, Contract.Enumarations.Book.CategoryType.GlobalSuccess),
                Book.CreateBookForSeedData(GlobalSuccess2, "Global Success 2", "Global-Success-2", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583472/edusource/Global-Success-2.jpg", 2, Contract.Enumarations.Book.CategoryType.GlobalSuccess),
                Book.CreateBookForSeedData(GlobalSuccess3, "Global Success 3", "Global-Success-3", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583470/edusource/Global-Success-3.jpg", 3, Contract.Enumarations.Book.CategoryType.GlobalSuccess),
                Book.CreateBookForSeedData(GlobalSuccess4, "Global Success 4", "Global-Success-4", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583471/edusource/Global-Success-4.jpg", 4, Contract.Enumarations.Book.CategoryType.GlobalSuccess),
                Book.CreateBookForSeedData(GlobalSuccess5, "Global Success 5", "Global-Success-5", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583474/edusource/Global-Success-5.webp", 5, Contract.Enumarations.Book.CategoryType.GlobalSuccess)
            );
        }
        if (!context.Products.Any())
        {
            context.Products.AddRange(
                Product.CreateProductForSeedData(listProduct[0], "Unit 1: Getting Started", 25000, Contract.Enumarations.Product.CategoryType.Exercise, "All Exercises for Unit 1: Getting Started of I Learn Smart Start Book", ContentType.Unit, 1, UploadType.Pdf, 10, 8.333, "Screenshot_2025-01-20_230706_g3dkld", "https://res.cloudinary.com/dc4eascme/image/upload/v1737389331/edusource/Screenshot_2025-01-20_230706_g3dkld.png", "I-Learn-Smart-Start-3-Getting-Started", "https://res.cloudinary.com/dc4eascme/image/upload/v1737366785/edusource/I-Learn-Smart-Start-3-Getting-Started.pdf", ILearnSmartStart3, staffId));
        }
        if (!context.ImageOfProducts.Any())
        {
            context.ImageOfProducts.AddRange(
                ImageOfProduct.CreateImageOfProductForSeedData("Screenshot_2025-01-20_230706_g3dkld", "https://res.cloudinary.com/dc4eascme/image/upload/v1737389331/edusource/Screenshot_2025-01-20_230706_g3dkld.png", listProduct[0]),
                ImageOfProduct.CreateImageOfProductForSeedData("Screenshot_2025-01-20_230741_ev2yle", "https://res.cloudinary.com/dc4eascme/image/upload/v1737389333/edusource/Screenshot_2025-01-20_230741_ev2yle.png", listProduct[0]),
                ImageOfProduct.CreateImageOfProductForSeedData("Screenshot_2025-01-20_230822_fwv2x0", "https://res.cloudinary.com/dc4eascme/image/upload/v1737389331/edusource/Screenshot_2025-01-20_230822_fwv2x0.png", listProduct[0]),
                ImageOfProduct.CreateImageOfProductForSeedData("Screenshot_2025-02-17_110346_rklbky", "https://res.cloudinary.com/dc4eascme/image/upload/v1739765060/Screenshot_2025-02-17_110346_rklbky.png", listProduct[0]),
                ImageOfProduct.CreateImageOfProductForSeedData("Screenshot_2025-02-17_110441_fhkrlc", "https://res.cloudinary.com/dc4eascme/image/upload/v1739765122/Screenshot_2025-02-17_110441_fhkrlc.png", listProduct[0]),
                ImageOfProduct.CreateImageOfProductForSeedData("Screenshot_2025-02-17_110623_xlpf5z", "https://res.cloudinary.com/dc4eascme/image/upload/v1739765207/Screenshot_2025-02-17_110623_xlpf5z.png", listProduct[0]),
                ImageOfProduct.CreateImageOfProductForSeedData("Screenshot_2025-02-17_110709_dtdkcs", "https://res.cloudinary.com/dc4eascme/image/upload/v1739765248/Screenshot_2025-02-17_110709_dtdkcs.png", listProduct[0]),
                ImageOfProduct.CreateImageOfProductForSeedData("Screenshot_2025-02-17_110739_x0arl3", "https://res.cloudinary.com/dc4eascme/image/upload/v1739765400/Screenshot_2025-02-17_110739_x0arl3.png", listProduct[0]),
                ImageOfProduct.CreateImageOfProductForSeedData("Screenshot_2025-02-17_110825_htpwnx", "https://res.cloudinary.com/dc4eascme/image/upload/v1739765401/Screenshot_2025-02-17_110825_htpwnx.png", listProduct[0]),
                ImageOfProduct.CreateImageOfProductForSeedData("Screenshot_2025-02-17_110925_k7btcv", "https://res.cloudinary.com/dc4eascme/image/upload/v1739765401/Screenshot_2025-02-17_110925_k7btcv.png", listProduct[0]));

        }
        context.SaveChanges();
    }
}
