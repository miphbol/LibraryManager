using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LibManagerMVC.Models.Author;
using LibManagerMVC.Services.AuthorServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LibManager.WebMvc.Controllers;

public class AuthorController : Controller
{
    private readonly ILogger<AuthorController> _logger;
    private readonly IAuthorService _authorService;

    public AuthorController(ILogger<AuthorController> logger,
            IAuthorService authorService)
    {
        _logger = logger;
        _authorService = authorService;
    }

    public async Task<IActionResult> Index()
    {
        List<AuthorIndexViewModel> authors = await _authorService.GetAllAuthorsAsync();

        return View(authors);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AuthorCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            TempData["ErrorMsg"] = "Model State is Invalid";
            return View(model);
        }

        await _authorService.CreateNewAuthorAsync(model);

        return RedirectToAction(nameof(Index));
    }

    [ActionName("Details")]
    public async Task<IActionResult> AuthorDetails(int id)
    {
        if (!ModelState.IsValid)
            return View();

        var author = await _authorService.GetAuthorByIdAsync(id);

        if (author == null)
            return RedirectToAction(nameof(Index));

        return View(author);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        if (!ModelState.IsValid)
            return View();

        var author = await _authorService.GetAuthorByIdEditAsync(id);

        if (author == null)
            return RedirectToAction(nameof(Index));

        return View(author);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(AuthorEditViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(ModelState);
        }

        var author = await _authorService.EditAuthorInfoAsync(model);

        if (!author)
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

        var author = await _authorService.GetAuthorByIdAsync(id);

        if (author == null)
            return RedirectToAction(nameof(Index));

        return View(author);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(AuthorDetailViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(ModelState);
        }

        await _authorService.DeleteAuthorAsync(model.Id);

        return RedirectToAction(nameof(Index));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}