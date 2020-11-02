using AppGameLoans.Domain.Entities;
using AppGameLoans.Domain.Interfaces.Repositories;
using AppGameLoans.Domain.ViewModel;
using AppGameLoans.Persistence.Context;
using AppGameLoans.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppGameLoans.Persistence.Repositories
{
    public class LoanRepository : BaseRepository<Loan>, ILoanRepository
    {
        public GameLoansDbContext _dbContext => DatabaseContext as GameLoansDbContext;

        public LoanRepository(GameLoansDbContext context) : base(context) { }

        public async Task<List<LoanViewModel>> GetAllLoansGameFriends()
        {
            return await _dbContext.Loan
                .AsNoTracking()
                .Include(h => h.Game)
                .Include(h => h.Friend)
                .Select(h => new LoanViewModel
                {
                    FriendName = h.Friend.Name,
                    GameName = h.Game.Name,
                    DateLoan = h.CreationDate.ToString("dd/MM/yyyy HH:mm"),
                    FriendId = h.FriendId,
                    GameId = h.GameId,
                    Id = h.Id
                }).ToListAsync();
        }

        public async Task<LoanViewModel> GetLoanByIAsync(Guid id)
        {

            return await _dbContext.Loan
               .AsNoTracking()
               .Include(h => h.Game)
               .Include(h => h.Friend)
               .Where( h => h.Id == id)
               .Select(h => new LoanViewModel
               {
                   FriendName = h.Friend.Name,
                   GameName = h.Game.Name,
                   DateLoan = h.CreationDate.ToString("dd/MM/yyyy HH:mm"),
                   FriendId = h.FriendId,
                   GameId = h.GameId,
                   Id = h.Id
               }).FirstOrDefaultAsync();
        }
    }
}
