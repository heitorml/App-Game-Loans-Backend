using System;
using System.Threading.Tasks;
using AppGameLoans.Domain.Entities;
using AppGameLoans.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppGameLoans.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : Controller
    {
        private readonly IFriendService _service;

        public FriendController(IFriendService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddFriendAsync([FromBody] Friend newFriend)
        {
            try
            {
                var response = await _service.AddNewFriend(newFriend);
                return Ok(response.Object);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
         
        }


        [HttpPut]
        public async Task<IActionResult> UpdateFriend([FromBody] Friend friend)
        {
            try
            {
                var response = await _service.UpdateFriend(friend);
                return Ok(response.Object);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFriends()
        {
            try
            {
                var response = await _service.GetFriends();
                return Ok(response.Object);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetFriendById([FromRoute] Guid id)
        {
            try
            {
                var response = await _service.GetFriendById(id);
                return Json(response.Object);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFriendById([FromRoute] Guid id)
        {
            try
            {
                var response = await _service.DeleteFriend(id);
                return Json(response.Object);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
