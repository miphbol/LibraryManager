using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibManagerMVC.Models.Loan
{
public class LoanEditViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime LoanDate { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }

        [Required]
        public int BookID { get; set; }
    }
}