using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lib.io.Dtos {
    public class BookDto {
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public byte GenreId { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; }
    }
}
