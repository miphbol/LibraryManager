using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibManagerMVC.Models.Author;

namespace LibManagerMVC.Services.AuthorServices;

public interface IAuthorService
{
    Task<AuthorIndexViewModel?> CreateNewAuthorAsync(AuthorCreateViewModel request);
    Task<List<AuthorIndexViewModel>> GetAllAuthorsAsync();
    Task<AuthorDetailViewModel?> GetAuthorByIdAsync(int id);
    Task<bool> EditAuthorInfoAsync(AuthorEditViewModel request);
    Task<bool> DeleteAuthorAsync(int id);
    Task<AuthorEditViewModel?> GetAuthorByIdEditAsync(int id);
}