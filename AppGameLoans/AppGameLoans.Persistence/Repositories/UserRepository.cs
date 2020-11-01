using AppGameLoans.Domain.Entities;
using AppGameLoans.Domain.Interface;
using AppGameLoans.Persistence.Context;
using AppGameLoans.Persistence.Repositories.Base;

namespace AppGameLoans.Persistence.Repositories
{
    public class UserRepository :BaseRepository<User>, IUserRepository
    {
        public GameLoansDbContext _dbContext => DatabaseContext as GameLoansDbContext;

        public UserRepository(GameLoansDbContext context) : base(context) { }
    }
}
