using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LibManagerMVC.Models.Book;
using LibManagerMVC.Services.BookServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LibManager.WebMvc.Controllers;

public class BookController : Controller
{
    private readonly ILogger<BookController> _logger;
    private readonly IBookService _bookService;

    public BookController(ILogger<BookController> logger,
            IBookService bookService)
    {
        _logger = logger;
        _bookService = bookService;
    }

    public async Task<IActionResult> Index()
    {
        List<BookIndexViewModel> books = await _bookService.GetAllBooksAsync();

        return View(books);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(BookCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            TempData["ErrorMsg"] = "Model State is Invalid";
            return View(model);
        }

        await _bookService.CreateNewBookAsync(model);

        return RedirectToAction(nameof(Index));
    }

    [ActionName("Details")]
    public async Task<IActionResult> BookDetails(int id)
    {
        if (!ModelState.IsValid)
            return View();

        var book = await _bookService.GetBookByIdAsync(id);

        if (book == null)
            return RedirectToAction(nameof(Index));

        return View(book);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        if (!ModelState.IsValid)
            return View();

        var book = await _bookService.GetBookByIdEditAsync(id);

        if (book == null)
            return RedirectToAction(nameof(Index));

        return View(book);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(BookEditViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(ModelState);
        }

        var book = await _bookService.EditBookInfoAsync(model);

        if (!book)
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

        var book = await _bookService.GetBookByIdAsync(id);

        if (book == null)
            return RedirectToAction(nameof(Index));

        return View(book);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(BookDetailViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(ModelState);
        }

        await _bookService.DeleteBookAsync(model.Id);

        return RedirectToAction(nameof(Index));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}