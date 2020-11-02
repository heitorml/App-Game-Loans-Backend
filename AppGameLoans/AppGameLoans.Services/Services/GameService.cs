using AppGameLoans.Domain.Entities;
using AppGameLoans.Domain.Helpers;
using AppGameLoans.Domain.Interfaces.Repositories;
using AppGameLoans.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace AppGameLoans.Services.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _repository;

        public GameService(IGameRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> AddNewGame(Game newGame)
        {
            var result = new Result();
            try
            {
                await _repository.AddAsync(newGame);
                result.ReturnInsert(newGame);
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
            }
            return result;
        }

        public Task<Result> DeleteGame(Guid idGame)
        {
            throw new NotImplementedException();
        }

        public Task<Result> GetGameById(Guid idGame)
        {
            throw new NotImplementedException();
        }

        public Task<Result> GetGames()
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdateGame(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
