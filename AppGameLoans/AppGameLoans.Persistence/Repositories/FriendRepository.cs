using AppGameLoans.Domain.Entities;
using AppGameLoans.Domain.Interface;
using AppGameLoans.Persistence.Context;
using AppGameLoans.Persistence.Repositories.Base;

namespace AppGameLoans.Persistence.Repositories
{
    public class FriendRepository : BaseRepository<Friend>,  IFriendRepository
    {
        public GameLoansDbContext _dbContext => DatabaseContext as GameLoansDbContext;

        public FriendRepository(GameLoansDbContext context) : base(context) { }
    }
}
