using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibManagerMVC.Models.Loan
{
    public class LoanDetailViewModel
    {
        [DisplayName("Loan Number")]
        public int Id { get; set; }

        [DisplayName("Loan Date")]
        public DateTime LoanDate { get; set; }

        [DisplayName("Return Date")]
        public DateTime ReturnDate { get; set; }

        [DisplayName("Book Title")]
        public string? BookTitle { get; set; }

        [DisplayName("Book Identifier")]
        public int BookID { get; set; }
    }
}

