using AppGameLoans.Domain.Dto;
using AppGameLoans.Domain.Entities;
using AppGameLoans.Domain.Helpers;
using AppGameLoans.Domain.Interfaces.Repositories;
using AppGameLoans.Domain.Interfaces.Services;
using AppGameLoans.Services.Util;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace AppGameLoans.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        const string DEFAULT_PASSWORD = "user123";
        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result> AddNewUser(UserDto user)
        {
            var result = new Result();
            try
            {
                user.Password = SecurityUtil.GenerateSHA256Hash(user.Password ?? DEFAULT_PASSWORD);
                var newUser = _mapper.Map<User>(user);
                await _repository.AddAsync(newUser);
                result.ReturnInsert(user);
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
            }
            return result;
        }

        public async Task<Result> DeleteUser(Guid idUser)
        {
            var result = new Result();
            try
            {
                await _repository.RemoveByIdAsync(idUser);
                result.ReturnInsert(idUser);
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
            }
            return result;
        }

        public async Task<Result> GetUserById(Guid idUser)
        {
            var result = new Result();
            try
            {
                var game = await _repository.GetByIdAsync(idUser);
                result.ReturnInsert(game);
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
            }
            return result;
        }

        public async Task<Result> GetUsers()
        {
            var result = new Result();
            try
            {
                var users = await _repository.GetAllAsync();
                result.ReturnInsert(users);
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
            }
            return result;
        }

        public async Task<Result> UpdateUser(UserDto user)
        {
            var result = new Result();
            try
            {
                var newUserData = await _repository.GetByIdAsync((Guid)user.Id);
                await _repository.UpdateAsync(_mapper.Map<UserDto, User>(user, newUserData));
                result.ReturnInsert(newUserData);
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
            }
            return result;
        }

        public async Task<User> GetUserByLogin(UserDto user)
        {
            return await _repository.GetUserByLogin(user);
        }
    }
}
