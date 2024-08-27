using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibManagerMVC.Models.Loan;

namespace LibManagerMVC.Services.LoanServices;

public interface ILoanService
{
    Task<LoanIndexViewModel?> CreateNewLoanAsync(LoanCreateViewModel request);
    Task<List<LoanIndexViewModel>> GetAllLoansAsync();
    Task<LoanDetailViewModel?> GetLoanByIdAsync(int id);
    Task<bool> EditLoanInfoAsync(LoanEditViewModel request);
    Task<bool> DeleteLoanAsync(int id);
    Task<LoanEditViewModel?> GetLoanByIdEditAsync(int id);
}