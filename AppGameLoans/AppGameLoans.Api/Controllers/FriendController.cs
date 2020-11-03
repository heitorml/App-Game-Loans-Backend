using System;
using System.Net;
using System.Threading.Tasks;
using AppGameLoans.Domain.Dto;
using AppGameLoans.Domain.Entities;
using AppGameLoans.Domain.Enum;
using AppGameLoans.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppGameLoans.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FriendController : Controller
    {
        private readonly IFriendService _service;

        public FriendController(IFriendService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddFriendAsync([FromBody] FriendDto newFriend)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await _service.AddNewFriend(newFriend);
                    return Ok(response.Object);
                }
                else
                {
                    return BadRequest();
                }
                    
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateFriend([FromBody] FriendDto friend)
        {
            try
            {
                var response = await _service.UpdateFriend(friend);
                return Ok(response.Object);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllFriends()
        {
            try
            {
                var response = await _service.GetFriends();
                return Ok(response.Object);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetFriendById([FromRoute] Guid id)
        {
            try
            {
                var response = await _service.GetFriendById(id);
                return Json(response.Object);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveFriendById([FromRoute] Guid id)
        {
            try
            {
                var response = await _service.DeleteFriend(id);
                return Json(response.Object);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
