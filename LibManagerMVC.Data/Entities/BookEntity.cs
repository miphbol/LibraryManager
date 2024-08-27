using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibManagerMVC.Data.Entities;

public class BookEntity
{
    [Key]
    public int Id { get; set; }
    [Required, MinLength(1), MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [ForeignKey(nameof(Author))]
    public int AuthorId { get; set; }
    public virtual AuthorEntity? Author { get; set; }
    public virtual List<LoanEntity>? Loans { get; set; }
}