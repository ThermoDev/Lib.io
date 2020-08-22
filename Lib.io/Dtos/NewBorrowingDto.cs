using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Lib.io.Models;

namespace Lib.io.Dtos {
    public class NewBorrowingDto {
        public int Id { get; set; }

        [Required]
        public int MemberId { get; set; }

        public List<int> BookIds { get; set; }
    }
}