using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibManagerMVC.Data;
using LibManagerMVC.Data.Entities;
using LibManagerMVC.Models.Author;
using Microsoft.EntityFrameworkCore;

namespace LibManagerMVC.Services.AuthorServices;

public class AuthorService : IAuthorService
{
    private readonly LibraryManagerDbContext _dbContext;
    private readonly IMapper _mapper;

    public AuthorService(LibraryManagerDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<AuthorIndexViewModel?> CreateNewAuthorAsync(AuthorCreateViewModel request)
    {
        var authorEntity = _mapper.Map<AuthorCreateViewModel, AuthorEntity>(request);
        _dbContext.Authors.Add(authorEntity);
        var numberOfChanges = await _dbContext.SaveChangesAsync();
        if(numberOfChanges == 1)
        {
            AuthorIndexViewModel response = _mapper.Map<AuthorEntity, AuthorIndexViewModel>(authorEntity);
            return response;
        }
        return null;
    }

    public async Task<bool> DeleteAuthorAsync(int id)
    {
        var author = await _dbContext.Authors.FindAsync(id);

        if (author == null)
            return false;

        _dbContext.Authors.Remove(author);
        return await _dbContext.SaveChangesAsync() == 1;
    }

    public async Task<bool> EditAuthorInfoAsync(AuthorEditViewModel request)
    {
        var authorExists = await _dbContext.Authors.AnyAsync(author =>
        author.Id == request.Id);

        if(!authorExists)
            return false;

        var newEntity = _mapper.Map<AuthorEditViewModel, AuthorEntity>(request);

        _dbContext.Entry(newEntity).State = EntityState.Modified;

        var numberOfChanges = await _dbContext.SaveChangesAsync();
        return numberOfChanges == 1;
    }

    public async Task<List<AuthorIndexViewModel>> GetAllAuthorsAsync()
    {
        var authors = await _dbContext.Authors
            .Select(entity => _mapper.Map<AuthorEntity, AuthorIndexViewModel>(entity))
            .ToListAsync();

            return authors;
    }

    public async Task<AuthorDetailViewModel?> GetAuthorByIdAsync(int id)
    {
        var authorEntity = await _dbContext.Authors
            .FirstOrDefaultAsync(e => e.Id == id);

        return authorEntity is null ? null : _mapper.Map<AuthorEntity, AuthorDetailViewModel>(authorEntity);
    }

    public async Task<AuthorEditViewModel?> GetAuthorByIdEditAsync(int id)
    {
        var authorEntity = await _dbContext.Authors
            .FirstOrDefaultAsync(e => e.Id == id);
        
        return authorEntity is null ? null : _mapper.Map<AuthorEntity, AuthorEditViewModel>(authorEntity);
    }
}