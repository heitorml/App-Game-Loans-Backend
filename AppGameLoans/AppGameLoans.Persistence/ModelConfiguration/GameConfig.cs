using AppGameLoans.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppGameLoans.Persistence.ModelConfiguration
{
    public class GameConfig : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable(nameof(Game));
            builder.HasKey(h => h.Id);
            builder.Property(h => h.Name).IsRequired();
            builder.Property(h => h.CreationDate);
        }
    }
}
