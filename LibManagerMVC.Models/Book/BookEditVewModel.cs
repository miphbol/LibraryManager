using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibManagerMVC.Models.Book

{
    public class BookEditViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int AuthorID { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "{0} must be at least {1} characters long.")]
        [MaxLength(100, ErrorMessage = "{0} must be no more than {1} characters long")]
        public string Title { get; set; } = string.Empty;
    }
}