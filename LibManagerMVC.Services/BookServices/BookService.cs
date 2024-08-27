using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibManagerMVC.Data;
using LibManagerMVC.Data.Entities;
using LibManagerMVC.Models.Book;
using Microsoft.EntityFrameworkCore;

namespace LibManagerMVC.Services.BookServices;

public class BookService : IBookService
{
    private readonly LibraryManagerDbContext _dbContext;
    private readonly IMapper _mapper;

    public BookService(LibraryManagerDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<BookIndexViewModel?> CreateNewBookAsync(BookCreateViewModel request)
    {
        var bookEntity = _mapper.Map<BookCreateViewModel, BookEntity>(request);
        _dbContext.Books.Add(bookEntity);
        var numberOfChanges = await _dbContext.SaveChangesAsync();
        if(numberOfChanges == 1)
        {
            BookIndexViewModel response = _mapper.Map<BookEntity, BookIndexViewModel>(bookEntity);
            return response;
        }
        return null;
    }

    public async Task<bool> DeleteBookAsync(int id)
    {
        var book = await _dbContext.Books.FindAsync(id);

        if (book == null)
            return false;

        _dbContext.Books.Remove(book);
        return await _dbContext.SaveChangesAsync() == 1;
    }

    public async Task<bool> EditBookInfoAsync(BookEditViewModel request)
    {
        var bookExists = await _dbContext.Books.AnyAsync(book =>
        book.Id == request.Id);

        if(!bookExists)
            return false;

        var newEntity = _mapper.Map<BookEditViewModel, BookEntity>(request);

        _dbContext.Entry(newEntity).State = EntityState.Modified;

        var numberOfChanges = await _dbContext.SaveChangesAsync();
        return numberOfChanges == 1;
    }

    public async Task<List<BookIndexViewModel>> GetAllBooksAsync()
    {
        var books = await _dbContext.Books
            .Select(entity => _mapper.Map<BookEntity, BookIndexViewModel>(entity))
            .ToListAsync();

            return books;
    }

    public async Task<BookDetailViewModel?> GetBookByIdAsync(int id)
    {
        var bookEntity = await _dbContext.Books
            .FirstOrDefaultAsync(e => e.Id == id);

        return bookEntity is null ? null : _mapper.Map<BookEntity, BookDetailViewModel>(bookEntity);
    }

    public async Task<BookEditViewModel?> GetBookByIdEditAsync(int id)
    {
        var bookEntity = await _dbContext.Books
            .FirstOrDefaultAsync(e => e.Id == id);
        
        return bookEntity is null ? null : _mapper.Map<BookEntity, BookEditViewModel>(bookEntity);
    }
}
