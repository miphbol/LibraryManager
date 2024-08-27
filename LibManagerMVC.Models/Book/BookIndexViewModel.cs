using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibManagerMVC.Models.Book

{
public class BookIndexViewModel
    {
        public int Id { get; set; }
        public int AuthorID { get; set; }
        public string? Title { get; set; }
    }
}