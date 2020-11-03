using AppGameLoans.Domain.Dto;
using AppGameLoans.Domain.Interfaces.Services;
using AppGameLoans.Services.Services;
using AppGameLoans.Services.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AppGameLoans.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUser([FromBody] UserDto newUser)
        {
            try
            {
                var response = await _service.AddNewUser(newUser);
                return Ok(response.Object);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto user)
        {
            try
            {
                var response = await _service.UpdateUser(user);
                return Ok(response.Object);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var response = await _service.GetUsers();
                return Ok(response.Object);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            try
            {
                var response = await _service.GetUserById(id);
                return Json(response.Object);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveUserById([FromRoute] Guid id)
        {
            try
            {
                var response = await _service.DeleteUser(id);
                return Json(response.Object);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] LoginDto model)
        {

            try
            {
                var user = await _service.GetUserByLogin(model);

                if (user == null)
                    return NotFound(new { message = "User not found" });

                if (user.Password != SecurityUtil.GenerateSHA256Hash(model.Password))
                    return NotFound(new { message = "Password incorrect" });

                var token = TokenService.GenerateToken(user);
                user.Password = "";
                return new
                {
                    user = user,
                    token = token
                };
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
