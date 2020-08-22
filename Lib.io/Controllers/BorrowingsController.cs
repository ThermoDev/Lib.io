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
    public class BorrowingsController : Controller {

        private ApplicationDbContext _context;

        // Constructor to initialize context
        public BorrowingsController() {
            _context = new ApplicationDbContext();
        }

        // Override Controller Method to dispose of context when done
        protected override void Dispose(bool disposing) {
            _context.Dispose();
        }

        // GET: Borrowings
        // Returns an ActionResult
        // ActionResult can be HTTPNotFound, EmptyResult, etc...
        // Nullable by using ?, string default to nullable
        // Paramaters are query values in Request
        public ActionResult Index(int? pageIndex, string sortBy) {

            if (User.IsInRole(RoleName.CanManageBorrowings)) {
                return View("TableEdit");
            }
            else {
                return View("TableRead");
            }

            // Previous configuration for supplying Borrowings to the View
            // Use this if we do not use RESTful Design
            /*
            var borrowings = _context.Borrowings.Include(b => b.Genre).ToList();
            if (!pageIndex.HasValue && String.IsNullOrEmpty(sortBy)) {
                return View("TableEdit", borrowings);
            }

            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
            */
        }

        // GET: Borrowings/New
        [Authorize(Roles = RoleName.CanManageBorrowings)]
        public ActionResult New() {

            return View("BorrowingForm");

        }
    }
}