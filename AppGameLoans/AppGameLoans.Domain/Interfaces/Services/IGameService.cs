using AppGameLoans.Domain.Dto;
using AppGameLoans.Domain.Helpers;
using System;
using System.Threading.Tasks;

namespace AppGameLoans.Domain.Interfaces.Services
{
    public interface IGameService
    {
        Task<Result> AddNewGame(GameDto newGame);
        Task<Result> UpdateGame(GameDto game);
        Task<Result> GetGames();
        Task<Result> GetGameById(Guid idGame);
        Task<Result> DeleteGame(Guid idGame);
    }
}
