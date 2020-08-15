using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lib.io.Models {
    public class Book {
        // POCO - Plain Old CLR(Common Language Runtime) Objects
        // Objects represents the state
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int NumberInStock { get; set; }
    }
}