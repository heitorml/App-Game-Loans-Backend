using AppGameLoans.Domain.Entities;
using AppGameLoans.Domain.Interfaces.Repositories;
using AppGameLoans.Persistence.Context;
using AppGameLoans.Persistence.Repositories.Base;

namespace AppGameLoans.Persistence.Repositories
{
    public class GameRepository :BaseRepository<Game>, IGameRepository
    {
        public GameLoansDbContext _dbContext => DatabaseContext as GameLoansDbContext;

        public GameRepository(GameLoansDbContext context) : base(context) { }
    }
}
