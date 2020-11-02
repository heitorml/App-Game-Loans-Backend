using AppGameLoans.Domain.Entities;
using AppGameLoans.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppGameLoans.Domain.Interfaces.Repositories
{
    public interface ILoanRepository : IRepository<Loan>
    {
        Task<List<LoanViewModel>> GetAllLoansGameFriends();

        Task<LoanViewModel> GetLoanByIAsync(Guid id);
    }
}
