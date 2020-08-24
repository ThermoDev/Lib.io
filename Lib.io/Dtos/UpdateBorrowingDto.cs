using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Lib.io.Models;

namespace Lib.io.Dtos
{
    public class UpdateBorrowingDto
    {
        public int Id { get; set; }
        public byte? BookId { get; set; }
        public byte? MemberId { get; set; }
        public DateTime? DateBorrowed { get; set; }
        public DateTime? DateReturned { get; set; }
        public bool HasReturned { get; set; }
    }
}