using AppGameLoans.Domain.Entities;
using AppGameLoans.Domain.Helpers;
using AppGameLoans.Domain.Interfaces.Repositories;
using AppGameLoans.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppGameLoans.Services.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _repository;

        public LoanService(ILoanRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> AddNewLoan(Loan loan)
        {
            var result = new Result();
            try
            {
                await _repository.AddAsync(loan);
                result.ReturnInsert(loan);
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
            }
            return result;
        }

        public Task<Result> DeleteLoan(Guid idLoan)
        {
            throw new NotImplementedException();
        }

        public Task<Result> GetLoanById(Guid idLoan)
        {
            throw new NotImplementedException();
        }

        public Task<Result> GetLoans()
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdateLoan(Loan loan)
        {
            throw new NotImplementedException();
        }
    }
}
