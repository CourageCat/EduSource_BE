using EduSource.Contract.Enumarations.Authentication;
using EduSource.Domain.Abstraction.Entities;

namespace EduSource.Domain.Entities;

public class Account : DomainEntity<Guid>
{
    public Account()
    {
    }

    public Account(string firstName,
        string lastName,
        string email,
        string phoneNumber,
        string password,
        string? cropAvatarUrl,
        string? cropAvatarId,
        string? fullAvatarUrl,
        string? fullAvatarId,
        string? cropCoverPhotoUrl,
        string? cropCoverPhotoId,
        string? fullCoverPhotoUrl,
        string? fullCoverPhotoId,
        string? biography,
        LoginType loginType,
        GenderType genderType,
        RoleType roleUserId,
        bool isDeleted)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Password = password;
        CropAvatarUrl = cropAvatarUrl;
        CropAvatarId = cropAvatarId;
        FullAvatarUrl = fullAvatarUrl;
        FullAvatarId = fullAvatarId;
        CropCoverPhotoUrl = cropAvatarUrl;
        CropCoverPhotoId = cropAvatarId;
        FullCoverPhotoUrl = fullAvatarUrl;
        FullCoverPhotoId = fullAvatarId;
        Biography = biography;
        LoginType = loginType;
        GenderType = genderType;
        RoleUserId = roleUserId;
        IsDeleted = isDeleted;
    }

    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string PhoneNumber { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public string? CropAvatarUrl { get; private set; }
    public string? CropAvatarId { get; private set; }
    public string? FullAvatarUrl { get; private set; }
    public string? FullAvatarId { get; private set; }
    public string? CropCoverPhotoUrl { get; private set; }
    public string? CropCoverPhotoId { get; private set; }
    public string? FullCoverPhotoUrl { get; private set; }
    public string? FullCoverPhotoId { get; private set; }
    public string? Biography { get; private set; }
    public LoginType LoginType { get; private set; }
    public GenderType GenderType { get; private set; }
    public RoleType RoleUserId { get; private set; }
    public virtual Role Role { get; private set; }
}
