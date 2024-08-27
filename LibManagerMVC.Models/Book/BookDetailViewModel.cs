using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibManagerMVC.Models.Book
{

    public class BookDetailViewModel
    {
        [DisplayName("Book Number")]
        public int Id { get; set; }
        
        [DisplayName("Author Identifier")]
        public int AuthorID { get; set; }

        [DisplayName("Name of Author")]
        public string? AuthorName { get; set; }

        [DisplayName("Book Title")]
        public string? Title { get; set; }
    }

}