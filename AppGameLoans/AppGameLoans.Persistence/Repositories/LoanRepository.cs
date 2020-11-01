using AppGameLoans.Domain.Entities;
using AppGameLoans.Domain.Interface;
using AppGameLoans.Persistence.Context;
using AppGameLoans.Persistence.Repositories.Base;

namespace AppGameLoans.Persistence.Repositories
{
    public class LoanRepository : BaseRepository<Loan>, ILoanRepository
    {
        public GameLoansDbContext _dbContext => DatabaseContext as GameLoansDbContext;

        public LoanRepository(GameLoansDbContext context) : base(context) { }
    }
}
