using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibManagerMVC.Data;
using LibManagerMVC.Data.Entities;
using LibManagerMVC.Models.Loan;
using Microsoft.EntityFrameworkCore;

namespace LibManagerMVC.Services.LoanServices;

public class LoanService : ILoanService
{
    private readonly LibraryManagerDbContext _dbContext;
    private readonly IMapper _mapper;

    public LoanService(LibraryManagerDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<LoanIndexViewModel?> CreateNewLoanAsync(LoanCreateViewModel request)
    {
        var loanEntity = _mapper.Map<LoanCreateViewModel, LoanEntity>(request);
        _dbContext.Loans.Add(loanEntity);
        var numberOfChanges = await _dbContext.SaveChangesAsync();
        if(numberOfChanges == 1)
        {
            LoanIndexViewModel response = _mapper.Map<LoanEntity, LoanIndexViewModel>(loanEntity);
            return response;
        }
        return null;
    }

    public async Task<bool> DeleteLoanAsync(int id)
    {
        var loan = await _dbContext.Loans.FindAsync(id);

        if (loan == null)
            return false;

        _dbContext.Loans.Remove(loan);
        return await _dbContext.SaveChangesAsync() == 1;
    }

    public async Task<bool> EditLoanInfoAsync(LoanEditViewModel request)
    {
        var loanExists = await _dbContext.Loans.AnyAsync(loan =>
        loan.Id == request.Id);

        if(!loanExists)
            return false;

        var newEntity = _mapper.Map<LoanEditViewModel, LoanEntity>(request);

        _dbContext.Entry(newEntity).State = EntityState.Modified;

        var numberOfChanges = await _dbContext.SaveChangesAsync();
        return numberOfChanges == 1;
    }

    public async Task<List<LoanIndexViewModel>> GetAllLoansAsync()
    {
        var loans = await _dbContext.Loans
            .Select(entity => _mapper.Map<LoanEntity, LoanIndexViewModel>(entity))
            .ToListAsync();

            return loans;
    }

    public async Task<LoanDetailViewModel?> GetLoanByIdAsync(int id)
    {
        var loanEntity = await _dbContext.Loans
            .FirstOrDefaultAsync(e => e.Id == id);

        return loanEntity is null ? null : _mapper.Map<LoanEntity, LoanDetailViewModel>(loanEntity);
    }

    public async Task<LoanEditViewModel?> GetLoanByIdEditAsync(int id)
    {
        var loanEntity = await _dbContext.Loans
            .FirstOrDefaultAsync(e => e.Id == id);
        
        return loanEntity is null ? null : _mapper.Map<LoanEntity, LoanEditViewModel>(loanEntity);
    }
}
