using AppGameLoans.Domain.Dto;
using AppGameLoans.Domain.Helpers;
using System;
using System.Threading.Tasks;

namespace AppGameLoans.Domain.Interfaces.Services
{
    public interface ILoanService
    {
        Task<Result> AddNewLoan(LoanDto loan);
        Task<Result> UpdateLoan(LoanDto loan);
        Task<Result> GetLoans();
        Task<Result> GetLoanById(Guid idLoan);
        Task<Result> DeleteLoan(Guid idLoan);
    }
}
