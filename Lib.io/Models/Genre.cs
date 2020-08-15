using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lib.io.Models {
    public class Genre {
        public byte Id { get; set; }
        [Required]
        public String Name { get; set; }
    }
}