using AppGameLoans.Domain;
using AppGameLoans.Domain.Dto;
using AppGameLoans.Domain.Entities;
using AppGameLoans.Domain.Interfaces.Repositories;
using AppGameLoans.Persistence.Context;
using AppGameLoans.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AppGameLoans.Persistence.Repositories
{
    public class UserRepository :BaseRepository<User>, IUserRepository
    {
        public GameLoansDbContext _dbContext => DatabaseContext as GameLoansDbContext;

        public UserRepository(GameLoansDbContext context) : base(context) { }

        public async Task<User> GetUserByLogin(LoginDto user)
        {
            return await _dbContext.User.FirstOrDefaultAsync(h => h.Email.Equals(user.Email));
        }
    }
}
