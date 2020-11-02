using AppGameLoans.Domain.Dto;
using AppGameLoans.Domain.Helpers;
using System;
using System.Threading.Tasks;

namespace AppGameLoans.Domain.Interfaces.Services
{
    public interface IFriendService
    {
        Task<Result> AddNewFriend(FriendDto friend);
        Task<Result> UpdateFriend(FriendDto friend);
        Task<Result> GetFriends();
        Task<Result> GetFriendById(Guid idFriend);
        Task<Result> DeleteFriend(Guid idFriend);
    }
}
