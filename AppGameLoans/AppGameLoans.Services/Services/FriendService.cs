using System;
using AppGameLoans.Domain.Entities;
using AppGameLoans.Domain.Interfaces.Repositories;
using AppGameLoans.Domain.Interfaces.Services;
using AppGameLoans.Domain.Helpers;
using System.Threading.Tasks;
using AutoMapper;
using AppGameLoans.Domain.Dto;

namespace AppGameLoans.Services.Services
{
    public class FriendService  : IFriendService
    {
        private readonly IFriendRepository _repository;
        private readonly IMapper _mapper;
        public FriendService(IFriendRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result> AddNewFriend(FriendDto entity)
        {
            var result = new Result();
            try
            {
                var newFriend = _mapper.Map<Friend>(entity);
                await _repository.AddAsync(newFriend);
                result.ReturnInsert(newFriend);
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

        public async Task<Result> UpdateFriend(FriendDto newFriend)
        {
            var result = new Result();
            try
            {
                var newFriendData = await _repository.GetByIdAsync((Guid)newFriend.Id);
                await _repository.UpdateAsync(_mapper.Map<FriendDto, Friend>(newFriend, newFriendData));
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
