using Core.Entities;
using Core.Utilities.Security.Hashing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasQueryFilter(u => !u.DeletedDate.HasValue);

        builder.HasMany(u => u.UserOperationClaims);
     
        builder.HasData(getSeeds());
    }

    private IEnumerable<User> getSeeds()
    {
        List<User> users = new();

        HashingHelper.CreatePasswordHash(
            password: "Mypass_1122",
            passwordHash: out byte[] passwordHash,
            passwordSalt: out byte[] passwordSalt
        );
        User adminUser =
            new()
            {
                Id = 1,
                FirstName = "Ahmet",
                LastName = "Ayyildiz",
                Email = "admin@admin.com",
                Status = true,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
        users.Add(adminUser);

        return users.ToArray();
    }
}
