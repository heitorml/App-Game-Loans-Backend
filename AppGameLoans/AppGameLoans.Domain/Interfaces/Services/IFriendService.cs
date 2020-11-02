using AppGameLoans.Domain.Entities;
using AppGameLoans.Domain.Helpers;
using System;
using System.Threading.Tasks;

namespace AppGameLoans.Domain.Interfaces.Services
{
    public interface IFriendService
    {
        Task<Result> AddNewFriend(Friend friend);
        Task<Result> UpdateFriend(Friend friend);
        Task<Result> GetFriends();
        Task<Result> GetFriendById(Guid idFriend);
        Task<Result> DeleteFriend(Guid idFriend);
    }
}
