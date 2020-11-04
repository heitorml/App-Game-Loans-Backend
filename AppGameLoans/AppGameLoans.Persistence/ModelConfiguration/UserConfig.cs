using AppGameLoans.Domain.Entities;
using AppGameLoans.Persistence.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace AppGameLoans.Persistence.ModelConfiguration
{
    class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));
            builder.HasKey(h => h.Id);
            builder.Property(h => h.Email).IsRequired();
            builder.Property(h => h.Profile).IsRequired();
            builder.Property(h => h.CreationDate).IsRequired();
            builder.Property(h => h.Name).IsRequired();
            builder.Property(h => h.Password).IsRequired();

            builder.HasData(UserSeed.DefaultUsers());
        }
    }
}
