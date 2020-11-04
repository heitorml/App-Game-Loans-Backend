using AppGameLoans.Domain.Entities;
using AppGameLoans.Persistence.ModelConfiguration;
using Microsoft.EntityFrameworkCore;

namespace AppGameLoans.Persistence.Context
{
    public class GameLoansDbContext : DbContext
    {

        public GameLoansDbContext(DbContextOptions<GameLoansDbContext> options) : base(options) {
            Database.Migrate();
        }

        public DbSet<Game> Game { get; set; }
        public DbSet<Friend> Friend { get; set; }
        public DbSet<Loan> Loan { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new GameConfig());
            modelBuilder.ApplyConfiguration(new FriendConfig());
            modelBuilder.ApplyConfiguration(new LoanConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
        }
    }
}
