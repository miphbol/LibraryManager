using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibManagerMVC.Data.Entities;

public class LoanEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    public DateTime LoanDate { get; set; }
    [Required]
    public DateTime ReturnDate { get; set; }

    [ForeignKey(nameof(Book))]
    public int BookId { get; set; }
    public virtual BookEntity? Book { get; set; }

}