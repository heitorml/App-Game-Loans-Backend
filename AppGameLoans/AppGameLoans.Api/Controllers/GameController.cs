using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppGameLoans.Domain.Entities;
using AppGameLoans.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppGameLoans.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GameController : Controller
    {
        private readonly IGameService _service;

        public GameController(IGameService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddNewGame([FromBody] Game newGame)
        {
            try
            {
                var response = await _service.AddNewGame(newGame);
                return Ok(response.Object);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }


        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateGame([FromBody] Game game)
        {
            try
            {
                var response = await _service.UpdateGame(game);
                return Ok(response.Object);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllGames()
        {
            try
            {
                var response = await _service.GetGames();
                return Ok(response.Object);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetGameById([FromRoute] Guid id)
        {
            try
            {
                var response = await _service.GetGameById(id);
                return Json(response.Object);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveGameById([FromRoute] Guid id)
        {
            try
            {
                var response = await _service.DeleteGame(id);
                return Json(response.Object);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
