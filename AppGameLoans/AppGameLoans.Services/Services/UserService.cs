using AppGameLoans.Domain.Entities;
using AppGameLoans.Domain.Helpers;
using AppGameLoans.Domain.Interfaces.Repositories;
using AppGameLoans.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppGameLoans.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> AddNewUser(User user)
        {
            var result = new Result();
            try
            {
                await _repository.AddAsync(user);
                result.ReturnInsert(user);
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
            }
            return result;
        }

        public Task<Result> DeleteUsern(Guid idUser)
        {
            throw new NotImplementedException();
        }

        public Task<Result> GetUserById(Guid idUser)
        {
            throw new NotImplementedException();
        }

        public Task<Result> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
