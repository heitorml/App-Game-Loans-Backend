using AppGameLoans.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AppGameLoans.Persistence.ModelConfiguration
{
    public class LoanConfig : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.ToTable(nameof(Loan));
            builder.HasKey(h => h.Id);
            builder.Property(h => h.FriendId);
            builder.Property(h => h.GameId).IsRequired();

            builder.HasOne(h => h.Friend).WithMany().HasForeignKey(h => h.FriendId);
            builder.HasOne(h => h.Game).WithMany().HasForeignKey(h => h.GameId);
        }
    }
}
