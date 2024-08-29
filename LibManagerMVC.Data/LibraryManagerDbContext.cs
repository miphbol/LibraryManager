using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibManagerMVC.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibManagerMVC.Data;

public class LibraryManagerDbContext : DbContext
{
    public LibraryManagerDbContext(DbContextOptions<LibraryManagerDbContext> options) : base(options)
    {
        
    }

    public DbSet<AuthorEntity> Authors { get; set; }
    public DbSet<BookEntity> Books { get; set; }
    public DbSet<LoanEntity> Loans { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<BookEntity>().HasData(
            new BookEntity
            {
                Id = 1,
                Title = "Blindsight",
                AuthorId = 1
            },
            new BookEntity
            {
                Id = 2,
                Title = "Hyperion",
                AuthorId = 2
            },
            new BookEntity
            {
                Id = 3,
                Title = "The Eye of the World",
                AuthorId = 3
            }
        );

        modelBuilder.Entity<AuthorEntity>().HasData(
            new AuthorEntity
            {
                Id = 1,
                Name = "Peter Watts",
            },
            new AuthorEntity
            {
                Id = 2,
                Name = "Dan Simmons",
            },
            new AuthorEntity
            {
                Id = 3,
                Name = "Robert Jordan",
            }
        );

        modelBuilder.Entity<LoanEntity>().HasData(
            new LoanEntity
            {
                Id = 1,
                LoanDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(7),
                BookId = 1,
            },
            new LoanEntity
            {
                Id = 2,
                LoanDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(7),
                BookId = 2,
            },
            new LoanEntity
            {
                Id = 3,
                LoanDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(7),
                BookId= 3,
            }
        );
    }
}