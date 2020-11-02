using AppGameLoans.Domain.Dto;
using AppGameLoans.Domain.Entities;
using AppGameLoans.Domain.Helpers;
using AppGameLoans.Domain.Interfaces.Repositories;
using AppGameLoans.Domain.Interfaces.Services;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace AppGameLoans.Services.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _repository;
        private readonly IMapper _mapper;
        public LoanService(ILoanRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result> AddNewLoan(LoanDto loan)
        {
            var result = new Result();
            try
            {
                var newLoan = _mapper.Map<Loan>(loan);
                await _repository.AddAsync(newLoan);
                result.ReturnInsert(newLoan);
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
            }
            return result;
        }

        public async Task<Result> DeleteLoan(Guid idLoan)
        {
            var result = new Result();
            try
            {
                await _repository.RemoveByIdAsync(idLoan);
                result.ReturnInsert(idLoan);
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
            }
            return result;
        }

        public async Task<Result> GetLoanById(Guid idLoan)
        {
            var result = new Result();
            try
            {
                var loan = await _repository.GetLoanByIAsync(idLoan);
                result.ReturnInsert(loan);
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
            }
            return result;
        }

        public async Task<Result> GetLoans()
        {
            var result = new Result();
            try
            {
                var loan = await _repository.GetAllLoansGameFriends();
                result.ReturnInsert(loan);
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
            }
            return result;
        }

        public async Task<Result> UpdateLoan(LoanDto loan)
        {
            var result = new Result();
            try
            {

                var newLoanData = await _repository.GetByIdAsync((Guid)loan.Id);
                await _repository.UpdateAsync(_mapper.Map<LoanDto, Loan>(loan, newLoanData));
                result.ReturnInsert(newLoanData);
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
            }
            return result;
        }
    }
}
