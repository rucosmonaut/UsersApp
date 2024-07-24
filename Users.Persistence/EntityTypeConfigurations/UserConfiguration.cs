namespace Users.Persistence.EntityTypeConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Domain;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(
        EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);

        builder
            .HasIndex(user => user.Id)
            .IsUnique();

        builder
            .Property(user => user.Email)
            .HasMaxLength(200);
    }
}
