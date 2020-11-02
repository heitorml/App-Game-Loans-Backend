using System;
using AppGameLoans.Domain.Entities;
using AppGameLoans.Domain.Interfaces.Repositories;
using AppGameLoans.Domain.Interfaces.Services;
using AppGameLoans.Domain.Helpers;
using System.Threading.Tasks;

namespace AppGameLoans.Services.Services
{
    public class FriendService  : IFriendService
    {
        private readonly IFriendRepository _repository;

        public FriendService(IFriendRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> AddNewFriend(Friend entity)
        {
            var result = new Result();
            try
            {
                await _repository.AddAsync(entity);
                result.ReturnInsert(entity);
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
            }
            return result;
        }

        public async Task<Result> DeleteFriend(Guid idFriend)
        {
            var result = new Result();
            try
            {
                await _repository.RemoveByIdAsync(idFriend);
                result.ReturnInsert(idFriend);
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
            }
            return result;
        }

        public async Task<Result> GetFriendById(Guid idFriend)
        {
            var result = new Result();
            try
            {
                var friend = await _repository.GetByIdAsync(idFriend);
                result.ReturnInsert(friend);
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
            }
            return result;
        }

        public async Task<Result> GetFriends()
        {
            var result = new Result();
            try
            {
                var friends = await _repository.GetAllAsync();
                result.ReturnInsert(friends);
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
            }
            return result;
        }

        public async Task<Result> UpdateFriend(Friend friend)
        {
            var result = new Result();
            try
            {
                var newFriendData = await _repository.GetByIdAsync(friend.Id);
                newFriendData.Name = friend.Name;
                newFriendData.CreationDate = friend.CreationDate;
                await _repository.UpdateAsync(newFriendData);
                result.ReturnInsert(newFriendData);
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
            }
            return result;
        }
    }
}
