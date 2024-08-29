using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LibManagerMVC.Models.Loan;
using LibManagerMVC.Services.LoanServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LibManager.WebMvc.Controllers;

public class LoanController : Controller
{
    private readonly ILogger<LoanController> _logger;
    private readonly ILoanService _loanService;

    public LoanController(ILogger<LoanController> logger,
            ILoanService loanService)
    {
        _logger = logger;
        _loanService = loanService;
    }

    public async Task<IActionResult> Index()
    {
        List<LoanIndexViewModel> loans = await _loanService.GetAllLoansAsync();

        return View(loans);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(LoanCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            TempData["ErrorMsg"] = "Model State is Invalid";
            return View(model);
        }

        await _loanService.CreateNewLoanAsync(model);

        return RedirectToAction(nameof(Index));
    }

    [ActionName("Details")]
    public async Task<IActionResult> LoanDetails(int id)
    {
        if (!ModelState.IsValid)
            return View();

        var loan = await _loanService.GetLoanByIdAsync(id);

        if (loan == null)
            return RedirectToAction(nameof(Index));

        return View(loan);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        if (!ModelState.IsValid)
            return View();

        var loan = await _loanService.GetLoanByIdEditAsync(id);

        if (loan == null)
            return RedirectToAction(nameof(Index));

        return View(loan);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(LoanEditViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(ModelState);
        }

        var loan = await _loanService.EditLoanInfoAsync(model);

        if (!loan)
        {
            ViewData["ErrorMsg"] = "Unable to save to the Database. Please try again.";
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction("Details", new { id = model.Id });
    }

    public async Task<IActionResult> Delete(int id)
    {
        if (!ModelState.IsValid)
            return View();

        var loan = await _loanService.GetLoanByIdAsync(id);

        if (loan == null)
            return RedirectToAction(nameof(Index));

        return View(loan);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(LoanDetailViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(ModelState);
        }

        await _loanService.DeleteLoanAsync(model.Id);

        return RedirectToAction(nameof(Index));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}