using AppGameLoans.Domain.Entities;
using AppGameLoans.Domain.Helpers;
using System;
using System.Threading.Tasks;

namespace AppGameLoans.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<Result> AddNewUser(User user);
        Task<Result> UpdateUser(User user);
        Task<Result> GetUsers();
        Task<Result> GetUserById(Guid idUser);
        Task<Result> DeleteUser(Guid idUser);
        Task<User> GetUserByLogin(User user);
    }
}
