using AppGameLoans.Domain.Dto;
using AppGameLoans.Domain.Entities;
using AppGameLoans.Domain.Helpers;
using System;
using System.Threading.Tasks;

namespace AppGameLoans.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<Result> AddNewUser(UserDto user);
        Task<Result> UpdateUser(UserDto user);
        Task<Result> GetUsers();
        Task<Result> GetUserById(Guid idUser);
        Task<Result> DeleteUser(Guid idUser);
        Task<User> GetUserByLogin(UserDto user);
    }
}
