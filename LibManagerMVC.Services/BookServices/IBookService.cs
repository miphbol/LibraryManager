using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibManagerMVC.Models.Book;

namespace LibManagerMVC.Services.BookServices;

public interface IBookService
{
    Task<BookIndexViewModel?> CreateNewBookAsync(BookCreateViewModel request);
    Task<List<BookIndexViewModel>> GetAllBooksAsync();
    Task<BookDetailViewModel?> GetBookByIdAsync(int id);
    Task<bool> EditBookInfoAsync(BookEditViewModel request);
    Task<bool> DeleteBookAsync(int id);
    Task<BookEditViewModel?> GetBookByIdEditAsync(int id);
}