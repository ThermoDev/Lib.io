using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lib.io.Models;

namespace Lib.io.Models {
    public class Borrowing {
        public int Id { get; set; }

        [Required]
        public Member Member { get; set; }

        public Book Book { get; set; }

        public DateTime DateBorrowed { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}