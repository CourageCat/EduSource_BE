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
        Guid ILearnSmartStart1Id = Guid.NewGuid();
        Guid ILearnSmartStart2Id = Guid.NewGuid();
        Guid ILearnSmartStart3Id = Guid.NewGuid();
        Guid ILearnSmartStart4Id = Guid.NewGuid();
        Guid ILearnSmartStart5Id = Guid.NewGuid();
        Guid FamilyAndFriends1Id = Guid.NewGuid();
        Guid FamilyAndFriends2Id = Guid.NewGuid();
        Guid FamilyAndFriends3Id = Guid.NewGuid();
        Guid FamilyAndFriends4Id = Guid.NewGuid();
        Guid FamilyAndFriends5Id = Guid.NewGuid();
        Guid GlobalSuccess1Id = Guid.NewGuid();
        Guid GlobalSuccess2Id = Guid.NewGuid();
        Guid GlobalSuccess3Id = Guid.NewGuid();
        Guid GlobalSuccess4Id = Guid.NewGuid();
        Guid GlobalSuccess5Id = Guid.NewGuid();
        int numberOfProducts = 4;
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
                Book.CreateBookForSeedData(ILearnSmartStart1Id, "I Learn Smart Start 1", "I-Learn-Smart-Start-1", "https://res.cloudinary.com/dc4eascme/image/upload/v1736586096/edusource/I-Learn-Smart-Start-1.jpg", 1, Contract.Enumarations.Book.CategoryType.ILearnSmartStart),
                Book.CreateBookForSeedData(ILearnSmartStart2Id, "I Learn Smart Start 2", "I-Learn-Smart-Start-2", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583438/edusource/I-Learn-Smart-Start-2.jpg", 2, Contract.Enumarations.Book.CategoryType.ILearnSmartStart),
                Book.CreateBookForSeedData(ILearnSmartStart3Id, "I Learn Smart Start 3", "I-Learn-Smart-Start-3", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583439/edusource/I-Learn-Smart-Start-3.png", 3, Contract.Enumarations.Book.CategoryType.ILearnSmartStart),
                Book.CreateBookForSeedData(ILearnSmartStart4Id, "I Learn Smart Start 4", "I-Learn-Smart-Start-4", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583438/edusource/I-Learn-Smart-Start-4.jpg", 4, Contract.Enumarations.Book.CategoryType.ILearnSmartStart),
                Book.CreateBookForSeedData(ILearnSmartStart5Id, "I Learn Smart Start 5", "I-Learn-Smart-Start-5", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583438/edusource/I-Learn-Smart-Start-5.jpg", 5, Contract.Enumarations.Book.CategoryType.ILearnSmartStart),
                Book.CreateBookForSeedData(FamilyAndFriends1Id, "Family and Friends 1", "Family-And-Friends-1", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583455/edusource/Family-And-Friends-1.png", 1, Contract.Enumarations.Book.CategoryType.FamilyAndFriends),
                Book.CreateBookForSeedData(FamilyAndFriends2Id, "Family and Friends 2", "Family-And-Friends-2", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583455/edusource/Family-And-Friends-2.png", 2, Contract.Enumarations.Book.CategoryType.FamilyAndFriends),
                Book.CreateBookForSeedData(FamilyAndFriends3Id, "Family and Friends 3", "Family-And-Friends-3", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583455/edusource/Family-And-Friends-3.png", 3, Contract.Enumarations.Book.CategoryType.FamilyAndFriends),
                Book.CreateBookForSeedData(FamilyAndFriends4Id, "Family and Friends 4", "Family-And-Friends-4", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583456/edusource/Family-And-Friends-4.png", 4, Contract.Enumarations.Book.CategoryType.FamilyAndFriends),
                Book.CreateBookForSeedData(FamilyAndFriends5Id, "Family and Friends 5", "Family-And-Friends-5", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583454/edusource/Family-And-Friends-5.jpg", 5, Contract.Enumarations.Book.CategoryType.FamilyAndFriends),
                Book.CreateBookForSeedData(GlobalSuccess1Id, "Global Success 1", "Global-Success-1", "https://res.cloudinary.com/dc4eascme/image/upload/v1736587391/edusource/Global-Success-1.jpg", 1, Contract.Enumarations.Book.CategoryType.GlobalSuccess),
                Book.CreateBookForSeedData(GlobalSuccess2Id, "Global Success 2", "Global-Success-2", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583472/edusource/Global-Success-2.jpg", 2, Contract.Enumarations.Book.CategoryType.GlobalSuccess),
                Book.CreateBookForSeedData(GlobalSuccess3Id, "Global Success 3", "Global-Success-3", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583470/edusource/Global-Success-3.jpg", 3, Contract.Enumarations.Book.CategoryType.GlobalSuccess),
                Book.CreateBookForSeedData(GlobalSuccess4Id, "Global Success 4", "Global-Success-4", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583471/edusource/Global-Success-4.jpg", 4, Contract.Enumarations.Book.CategoryType.GlobalSuccess),
                Book.CreateBookForSeedData(GlobalSuccess5Id, "Global Success 5", "Global-Success-5", "https://res.cloudinary.com/dc4eascme/image/upload/v1736583474/edusource/Global-Success-5.webp", 5, Contract.Enumarations.Book.CategoryType.GlobalSuccess)
            );
        }
        if (!context.Products.Any())
        {
            context.Products.AddRange(
                //I Learn Smart Start 3 - Unit 1 - Exercises
                Product.CreateProductForSeedData(listProduct[0], "Unit 1: Getting Started", 25000, Contract.Enumarations.Product.CategoryType.Exercise, "All Exercises for Unit 1: Getting Started of I Learn Smart Start 3 Book", ContentType.Unit, 1, UploadType.Pdf, 10, 8.333, "Screenshot_2025-01-20_230706_g3dkld", "https://res.cloudinary.com/dc4eascme/image/upload/v1737389331/edusource/Screenshot_2025-01-20_230706_g3dkld.png", "I-Learn-Smart-Start-3-Getting-Started", "https://res.cloudinary.com/dc4eascme/image/upload/v1737366785/edusource/I-Learn-Smart-Start-3-Getting-Started.pdf", ILearnSmartStart3Id, staffId),
                //I Learn Smart Start 3 - Unit 5 - Exercises
                Product.CreateProductForSeedData(listProduct[1], "Unit 5: Jobs and occupations", 23000, Contract.Enumarations.Product.CategoryType.Exercise, "All Exercises for Unit 5: Jobs and occupations of I Learn Smart Start 3 Book", ContentType.Unit, 5, UploadType.Pdf, 6, 2.23, "f6d3260c-5357-4bbd-a695-4924d3373ca7_f2ranb", "https://res.cloudinary.com/dc4eascme/image/upload/v1740067871/edusource/f6d3260c-5357-4bbd-a695-4924d3373ca7_f2ranb.png", "I-Learn-Smart-Start-3-Unit-5-Exercise", "https://res.cloudinary.com/dc4eascme/image/upload/v1740067745/edusource/I-Learn-Smart-Start-3-Unit-5-Exercise.pdf", ILearnSmartStart3Id, staffId),
                //I Learn Smart Start 3 - Unit 6 - Exercises
                Product.CreateProductForSeedData(listProduct[2], "Unit 6: Classroom Items", 20000, Contract.Enumarations.Product.CategoryType.Exercise, "All Exercises for Unit 6: Classroom Items of I Learn Smart Start 3 Book", ContentType.Unit, 6, UploadType.Pdf, 5, 1.126, "476667624_3950096128644390_3722047459084752702_n_aedtao", "https://res.cloudinary.com/dc4eascme/image/upload/v1740070678/edusource/476667624_3950096128644390_3722047459084752702_n_aedtao.png", "I-Learn-Smart-Start-3-Unit-6-Exercise", "https://res.cloudinary.com/dc4eascme/image/upload/v1740070473/edusource/I-Learn-Smart-Start-3-Unit-6-Exercise.pdf", ILearnSmartStart3Id, staffId),
                //I Learn Smart Start 3 - Unit 5 - Tests
                Product.CreateProductForSeedData(listProduct[3], "Unit 5: Jobs and occupations", 17000, Contract.Enumarations.Product.CategoryType.Test, "All Tests for Unit 5: Jobs and occupations of I Learn Smart Start 3 Book", ContentType.Unit, 5, UploadType.Pdf, 3, 1.559, "476898424_516722711033057_8916288325621536975_n_fvn3ly", "https://res.cloudinary.com/dc4eascme/image/upload/v1740071632/edusource/476898424_516722711033057_8916288325621536975_n_fvn3ly.png", "I-Learn-Smart-Start-3-Unit-5-Test", "https://res.cloudinary.com/dc4eascme/image/upload/v1740071272/edusource/I-Learn-Smart-Start-3-Unit-5-Test.pdf", ILearnSmartStart3Id, staffId)
                );


        }
        if (!context.ImageOfProducts.Any())
        {
            context.ImageOfProducts.AddRange(
                //I Learn Smart Start 3 - Unit 1 - Exercises
                ImageOfProduct.CreateImageOfProductForSeedData("Screenshot_2025-01-20_230706_g3dkld", "https://res.cloudinary.com/dc4eascme/image/upload/v1737389331/edusource/Screenshot_2025-01-20_230706_g3dkld.png", listProduct[0]),
                ImageOfProduct.CreateImageOfProductForSeedData("Screenshot_2025-01-20_230741_ev2yle", "https://res.cloudinary.com/dc4eascme/image/upload/v1737389333/edusource/Screenshot_2025-01-20_230741_ev2yle.png", listProduct[0]),
                ImageOfProduct.CreateImageOfProductForSeedData("Screenshot_2025-01-20_230822_fwv2x0", "https://res.cloudinary.com/dc4eascme/image/upload/v1737389331/edusource/Screenshot_2025-01-20_230822_fwv2x0.png", listProduct[0]),
                ImageOfProduct.CreateImageOfProductForSeedData("Screenshot_2025-02-17_110346_rklbky", "https://res.cloudinary.com/dc4eascme/image/upload/v1739765060/Screenshot_2025-02-17_110346_rklbky.png", listProduct[0]),
                ImageOfProduct.CreateImageOfProductForSeedData("Screenshot_2025-02-17_110441_fhkrlc", "https://res.cloudinary.com/dc4eascme/image/upload/v1739765122/Screenshot_2025-02-17_110441_fhkrlc.png", listProduct[0]),
                ImageOfProduct.CreateImageOfProductForSeedData("Screenshot_2025-02-17_110623_xlpf5z", "https://res.cloudinary.com/dc4eascme/image/upload/v1739765207/Screenshot_2025-02-17_110623_xlpf5z.png", listProduct[0]),
                ImageOfProduct.CreateImageOfProductForSeedData("Screenshot_2025-02-17_110709_dtdkcs", "https://res.cloudinary.com/dc4eascme/image/upload/v1739765248/Screenshot_2025-02-17_110709_dtdkcs.png", listProduct[0]),
                ImageOfProduct.CreateImageOfProductForSeedData("Screenshot_2025-02-17_110739_x0arl3", "https://res.cloudinary.com/dc4eascme/image/upload/v1739765400/Screenshot_2025-02-17_110739_x0arl3.png", listProduct[0]),
                ImageOfProduct.CreateImageOfProductForSeedData("Screenshot_2025-02-17_110825_htpwnx", "https://res.cloudinary.com/dc4eascme/image/upload/v1739765401/Screenshot_2025-02-17_110825_htpwnx.png", listProduct[0]),
                ImageOfProduct.CreateImageOfProductForSeedData("Screenshot_2025-02-17_110925_k7btcv", "https://res.cloudinary.com/dc4eascme/image/upload/v1739765401/Screenshot_2025-02-17_110925_k7btcv.png", listProduct[0]),
                //I Learn Smart Start 3 - Unit 5 - Exercises
                ImageOfProduct.CreateImageOfProductForSeedData("f6d3260c-5357-4bbd-a695-4924d3373ca7_f2ranb", "https://res.cloudinary.com/dc4eascme/image/upload/v1740067871/edusource/f6d3260c-5357-4bbd-a695-4924d3373ca7_f2ranb.png", listProduct[1]),
                ImageOfProduct.CreateImageOfProductForSeedData("597e6be1-3f45-4be2-96dc-2d14752babb0_gjwijg", "https://res.cloudinary.com/dc4eascme/image/upload/v1740067900/edusource/597e6be1-3f45-4be2-96dc-2d14752babb0_gjwijg.png", listProduct[1]),
                ImageOfProduct.CreateImageOfProductForSeedData("ea021ff1-4b0e-415a-bb4b-f26b73af9055_erkhd7", "https://res.cloudinary.com/dc4eascme/image/upload/v1740067918/edusource/ea021ff1-4b0e-415a-bb4b-f26b73af9055_erkhd7.png", listProduct[1]),
                ImageOfProduct.CreateImageOfProductForSeedData("ff6dc57c-eca0-46cc-be83-1a673df54e81_ckbuho", "https://res.cloudinary.com/dc4eascme/image/upload/v1740067954/edusource/ff6dc57c-eca0-46cc-be83-1a673df54e81_ckbuho.png", listProduct[1]),
                ImageOfProduct.CreateImageOfProductForSeedData("16028ac1-dfa8-4203-bc77-69436776cbbe_vzs49w", "https://res.cloudinary.com/dc4eascme/image/upload/v1740067953/edusource/16028ac1-dfa8-4203-bc77-69436776cbbe_vzs49w.png", listProduct[1]),
                ImageOfProduct.CreateImageOfProductForSeedData("ac57e6a3-f0a9-4608-9f32-681b1fab3f98_jnhdgo", "https://res.cloudinary.com/dc4eascme/image/upload/v1740067952/edusource/ac57e6a3-f0a9-4608-9f32-681b1fab3f98_jnhdgo.png", listProduct[1]),
                //I Learn Smart Start 3 - Unit 6 - Exercises
                ImageOfProduct.CreateImageOfProductForSeedData("476667624_3950096128644390_3722047459084752702_n_aedtao", "https://res.cloudinary.com/dc4eascme/image/upload/v1740070678/edusource/476667624_3950096128644390_3722047459084752702_n_aedtao.png", listProduct[2]),
                ImageOfProduct.CreateImageOfProductForSeedData("480842067_617513641197903_6751550858276571459_n_mk2qsh", "https://res.cloudinary.com/dc4eascme/image/upload/v1740070684/edusource/480842067_617513641197903_6751550858276571459_n_mk2qsh.png", listProduct[2]),
                ImageOfProduct.CreateImageOfProductForSeedData("480019426_1841460996623080_3227391006321734421_n_cci8g0", "https://res.cloudinary.com/dc4eascme/image/upload/v1740070692/edusource/480019426_1841460996623080_3227391006321734421_n_cci8g0.png", listProduct[2]),
                ImageOfProduct.CreateImageOfProductForSeedData("481131807_1340369817381918_8877559266933682545_n_pjfbi1", "https://res.cloudinary.com/dc4eascme/image/upload/v1740070697/edusource/481131807_1340369817381918_8877559266933682545_n_pjfbi1.png", listProduct[2]),
                ImageOfProduct.CreateImageOfProductForSeedData("479427371_1157989708586096_3913814768610771486_n_fkmqt3", "https://res.cloudinary.com/dc4eascme/image/upload/v1740070702/edusource/479427371_1157989708586096_3913814768610771486_n_fkmqt3.png", listProduct[2]),
                //I Learn Smart Start 3 - Unit 5 - Tests
                ImageOfProduct.CreateImageOfProductForSeedData("476898424_516722711033057_8916288325621536975_n_fvn3ly", "https://res.cloudinary.com/dc4eascme/image/upload/v1740071632/edusource/476898424_516722711033057_8916288325621536975_n_fvn3ly.png", listProduct[3]),
                ImageOfProduct.CreateImageOfProductForSeedData("476890688_9313465715439518_2551059009486639375_n_exkptm", "https://res.cloudinary.com/dc4eascme/image/upload/v1740071639/edusource/476890688_9313465715439518_2551059009486639375_n_exkptm.png", listProduct[3]),
                ImageOfProduct.CreateImageOfProductForSeedData("480004236_1422923598918877_8401951042523901775_n_iiba0p", "https://res.cloudinary.com/dc4eascme/image/upload/v1740071649/edusource/480004236_1422923598918877_8401951042523901775_n_iiba0p.png", listProduct[3])
                );

        }
        context.SaveChanges();
    }
}
