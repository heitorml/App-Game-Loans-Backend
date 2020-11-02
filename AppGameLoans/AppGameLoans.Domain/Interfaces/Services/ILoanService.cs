using AppGameLoans.Domain.Entities;
using AppGameLoans.Domain.Helpers;
using System;
using System.Threading.Tasks;

namespace AppGameLoans.Domain.Interfaces.Services
{
    public interface ILoanService
    {
        Task<Result> AddNewLoan(Loan loan);
        Task<Result> UpdateLoan(Loan loan);
        Task<Result> GetLoans();
        Task<Result> GetLoanById(Guid idLoan);
        Task<Result> DeleteLoan(Guid idLoan);
    }
}
