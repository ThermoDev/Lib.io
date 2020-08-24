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
        public ActionResult Index(int? pageIndex, string sortBy)
        {

            if (User.IsInRole(RoleName.CanManageBorrowings))
            {
                return View("TableEdit");
            }
            else
            {
                return View("TableRead");
            }
        }

        // GET: Borrowings/All
        // Returns an ActionResult
        // ActionResult can be HTTPNotFound, EmptyResult, etc...
        // Nullable by using ?, string default to nullable
        // Paramaters are query values in Request
        public ActionResult All(int? pageIndex, string sortBy)
        {

            if (User.IsInRole(RoleName.CanManageBorrowings))
            {
                return View("AllTableEdit");
            }
            else
            {
                return View("AllTableView");
            }
        }

        // GET: Borrowings/New
        [Authorize(Roles = RoleName.CanManageBorrowings)]
        public ActionResult New() {
            return View("BorrowingForm");
        }
    }
}