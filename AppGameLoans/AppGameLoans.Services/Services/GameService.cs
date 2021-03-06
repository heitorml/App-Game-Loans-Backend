﻿using AppGameLoans.Domain.Dto;
using AppGameLoans.Domain.Entities;
using AppGameLoans.Domain.Helpers;
using AppGameLoans.Domain.Interfaces.Repositories;
using AppGameLoans.Domain.Interfaces.Services;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace AppGameLoans.Services.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _repository;
        private readonly IMapper _mapper;
        public GameService(IGameRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result> AddNewGame(GameDto entity)
        {
            var result = new Result();
            try
            {
                var newGame =  _mapper.Map<Game>(entity);
                await _repository.AddAsync(newGame);
                result.ReturnInsert(newGame);
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
            }
            return result;
        }

        public async Task<Result> DeleteGame(Guid idGame)
        {
            var result = new Result();
            try
            {
                await _repository.RemoveByIdAsync(idGame);
                result.ReturnInsert(idGame);
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
            }
            return result;
        }

        public async Task<Result> GetGameById(Guid idGame)
        {
            var result = new Result();
            try
            {
                var game = await _repository.GetByIdAsync(idGame);
                result.ReturnInsert(game);
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
            }
            return result;
        }

        public async Task<Result> GetGames()
        {
            var result = new Result();
            try
            {
                var games = await _repository.GetAllAsync();
                result.ReturnInsert(games);
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
            }
            return result;
        }

        public async Task<Result> UpdateGame(GameDto newGame)
        {
            var result = new Result();
            try
            {
                var newGameData = await _repository.GetByIdAsync((Guid)newGame.Id);
                await _repository.UpdateAsync(_mapper.Map<GameDto, Game>(newGame, newGameData));;
                await _repository.UpdateAsync(newGameData);
                result.ReturnInsert(newGameData);
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
            }
            return result;
        }
    }
}
