using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Lib.io.Models;

namespace Lib.io.ViewModels {
    public class BookViewFormModel {
        // Constructor for new book
        public BookViewFormModel() {
            Id = 0;
        }

        // Constructor for existing book
        public BookViewFormModel(Book book) {
            Id = book.Id;
            Name = book.Name;
            ReleaseDate = book.ReleaseDate;
            NumberInStock = book.NumberInStock;
            GenreId = book.GenreId;
        }

        public IEnumerable<Genre> Genres { get; set; }

        // A Pure-View model
        // Fetched from Book Model
        public int? Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Number in Stock")]
        public int? NumberInStock { get; set; }
    }
}