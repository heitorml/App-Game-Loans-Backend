using AppGameLoans.Domain.Dto;
using AppGameLoans.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AppGameLoans.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : Controller
    {
        private readonly ILoanService _service;

        public LoanController(ILoanService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddNewGame([FromBody] LoanDto newLoan)
        {
            try
            {
                var response = await _service.AddNewLoan(newLoan);
                return Ok(response.Object);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }


        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateLoan([FromBody] LoanDto loan)
        {
            try
            {
                var response = await _service.UpdateLoan(loan);
                return Ok(response.Object);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllLoans()
        {
            try
            {
                var response = await _service.GetLoans();
                return Ok(response.Object);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetLoanById([FromRoute] Guid id)
        {
            try
            {
                var response = await _service.GetLoanById(id);
                return Json(response.Object);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveLoanById([FromRoute] Guid id)
        {
            try
            {
                var response = await _service.DeleteLoan(id);
                return Json(response.Object);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
