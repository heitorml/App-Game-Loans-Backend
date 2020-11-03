using AppGameLoans.Domain.Dto;
using AppGameLoans.Domain.Entities;
using System.Threading.Tasks;

namespace AppGameLoans.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByLogin(LoginDto user);
    }
}
