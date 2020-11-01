using Microsoft.EntityFrameworkCore;
using AppGameLoans.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppGameLoans.Persistence.ModelConfiguration
{
    public class FriendConfig : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.ToTable(nameof(Friend));
            builder.HasKey(h => h.Id);
            builder.Property(h => h.Name).IsRequired();
            builder.Property(h => h.CreationDate);
            
        }
    }
}
