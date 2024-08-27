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
}