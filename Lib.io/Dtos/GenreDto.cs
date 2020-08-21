using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lib.io.Dtos {
    public class GenreDto {
        public byte Id { get; set; }
        [Required]
        public String Name { get; set; }
    }
}