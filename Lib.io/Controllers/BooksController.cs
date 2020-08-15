using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Lib.io.Models;
using Lib.io.ViewModels;

namespace Lib.io.Controllers {
    // Derives from Controller class
    public class BooksController : Controller {

        // Temp Psuedo-Database
        public static IEnumerable<Book> books = new List<Book> {
                new Book {Id=0, Name = "Case of the Singing Monkey" },
                new Book {Id=1, Name = "Primed for Crime" }
            };


        // GET: Books
        // Returns an ActionResult
        // ActionResult can be HTTPNotFound, EmptyResult, etc...
        // Nullable by using ?, string default to nullable
        // Paramaters are query values in Request
        public ActionResult Index(int? pageIndex, string sortBy) {
            if(!pageIndex.HasValue && String.IsNullOrEmpty(sortBy)) {
                return View(books);
            }

            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
        // GET: Books/Random
        public ActionResult Random() {
            var book = new Book() { Name = "The Ruins of the Galaxy" };
            var members = new List<Member> {
                new Member { Name = "Member 1" },
                new Member { Name = "Member 2" }
            };

            // Creating a View Model that stores a Book and a list of Members
            var viewModel = new RandomBookViewModel {
                Book = book,
                Members = members
            };

            // Can only return view if we have the relevant Controller
            // Inherited from the base Controller class
            return View(viewModel);
        }
        // Attribute Route with 4-digit Year and 2-digit month ranging from 01-12
        [Route("books/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month) {
            return Content(year + "/" + month);
        }

        // Parse id as parameter which is setup by RouteConfig
        public ActionResult Edit(int id) {
            return Content("Id=" + id);
        }
    }
}