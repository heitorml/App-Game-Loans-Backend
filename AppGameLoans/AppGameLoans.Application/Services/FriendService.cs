using AppGameLoans.Domain.Entities;
using AppGameLoans.Domain.Helpers;
using AppGameLoans.Domain.Interface;
using System;
using System.Threading.Tasks;

namespace AppGameLoans.Application.Services
{
    public class FriendService
    {
        private readonly IFriendRepository _repository;

        public FriendService(IFriendRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> AddFriendAsync(Friend friend)
        {
            var result = new Result();
            try
            {
                 await _repository.AddAsync(friend);
                 result.ReturnInsert(friend);
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
            }
            return result;

        }
    }
}
