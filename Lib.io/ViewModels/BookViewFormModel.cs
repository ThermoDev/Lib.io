using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lib.io.Models;

namespace Lib.io.ViewModels {
    public class BookViewFormModel {
        public IEnumerable<Genre> Genres { get; set; }
        public Book Book { get; set; }
    }
}