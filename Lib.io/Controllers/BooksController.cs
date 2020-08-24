using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Lib.io.Models;
using Lib.io.ViewModels;
using System.Data.Entity;

namespace Lib.io.Controllers {
    // Derives from Controller class
    public class BooksController : Controller {

        private ApplicationDbContext _context;

        // Constructor to initialize context
        public BooksController() {
            _context = new ApplicationDbContext();
        }

        // Override Controller Method to dispose of context when done
        protected override void Dispose(bool disposing) {
            _context.Dispose();
        }

        // GET: Books
        // Returns an ActionResult
        // ActionResult can be HTTPNotFound, EmptyResult, etc...
        // Nullable by using ?, string default to nullable
        // Paramaters are query values in Request
        public ActionResult Index(int? pageIndex, string sortBy) {

            if (User.IsInRole(RoleName.CanManageBooks)) {
                return View("TableEdit");
            }
            else {
                return View("TableRead");
            }

            // Previous configuration for supplying Books to the View
            // Use this if we do not use RESTful Design
            /*
            var books = _context.Books.Include(b => b.Genre).ToList();
            if (!pageIndex.HasValue && String.IsNullOrEmpty(sortBy)) {
                return View("TableEdit", books);
            }

            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
            */
    }

        // GET:Books/New
        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult New() {
            var genres = _context.Genres.ToList();
            var viewModel = new BookViewFormModel {
                Genres = genres
            };
            ViewBag.Message = "Create Book";
            return View("BookForm", viewModel);
        }

        // GET:Books/Edit/<id>
        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult Edit(int id) {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if (book == null)
                return HttpNotFound();
            var viewModel = new BookViewFormModel(book) {
                Genres = _context.Genres.ToList()
            };
            ViewBag.Message = "Edit Book";
            return View("BookForm", viewModel);
        }


        // Model-Binding that is fetched from request data
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult Save(Book book) {
            if (!ModelState.IsValid) {
                var viewModel = new BookViewFormModel(book) {
                    Genres = _context.Genres.ToList()
                };

                ViewBag.Message = book.Id == 0 ? "Create Book" : "Edit Book";
                return View("BookForm", viewModel);
            }

            if (book.Id == 0) {
                book.DateAdded = DateTime.Today;
                _context.Books.Add(book);
            }
            else {
                var bookInDb = _context.Books.Single(b => b.Id == book.Id);

                bookInDb.Name = book.Name;
                bookInDb.ReleaseDate = book.ReleaseDate;
                bookInDb.GenreId = book.GenreId;
                bookInDb.NumberInStock = book.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Books");
        }


        // Attribute Route with 4-digit Year and 2-digit month ranging from 01-12
        [Route("books/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month) {
            return Content(year + "/" + month);
        }

        // Books/Details/<id>
        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult Details(int id) {
            var book = _context.Books.Include(b => b.Genre).SingleOrDefault(b => b.Id == id);
            if (book == null)
                return HttpNotFound();
            else
                return View(book);
        }
    }
}