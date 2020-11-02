using AppGameLoans.Domain.Entities;
using AppGameLoans.Domain.Helpers;
using System;
using System.Threading.Tasks;

namespace AppGameLoans.Domain.Interfaces.Services
{
    public interface IGameService
    {
        Task<Result> AddNewGame(Game newGame);
        Task<Result> UpdateGame(Game game);
        Task<Result> GetGames();
        Task<Result> GetGameById(Guid idGame);
        Task<Result> DeleteGame(Guid idGame);
    }
}
