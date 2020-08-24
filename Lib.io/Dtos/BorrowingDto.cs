using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Lib.io.Models;


namespace Lib.io.Dtos {
    // The Dto that displays all current Borrowings from the Lib
    public class BorrowingDto {
        public int Id { get; set; }

        [Required]
        public MemberDto Member { get; set; }

        [Required]
        public BookDto Book { get; set; }

        public DateTime DateReturned { get; set; }
        public DateTime DateBorrowed { get; set; }

        [Required]
        public Boolean HasReturned { get; set; }
    }
}