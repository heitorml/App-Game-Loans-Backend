using AppGameLoans.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace AppGameLoans.Persistence.ModelConfiguration
{
    class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));
            builder.HasKey(h => h.Id);
            builder.Property(h => h.Email);
            builder.Property(h => h.CreationDate).IsRequired();
            builder.Property(h => h.Name).IsRequired();
            builder.Property(h => h.Password).IsRequired();
        }
    }
}
