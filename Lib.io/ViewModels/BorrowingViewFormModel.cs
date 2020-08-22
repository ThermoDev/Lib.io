using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Lib.io.Models;

namespace Lib.io.ViewModels {
    public class BorrowingViewFormModel {
        // Constructor for new book
        public BorrowingViewFormModel() {
            Id = 0;
        }

        // Constructor for existing book
        public BorrowingViewFormModel(Borrowing borrowing) {
            Id = borrowing.Id;
        }

        public IEnumerable<Member> Members { get; set; }
        public IEnumerable<Book> Books { get; set; }

        // A Pure-View model
        // Fetched from Borrowing Model
        public int? Id { get; set; }
    }
}