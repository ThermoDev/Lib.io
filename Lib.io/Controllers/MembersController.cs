using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lib.io.Models;

namespace Lib.io.Controllers {
    public class MembersController : Controller {

        private ApplicationDbContext _context;

        public MembersController() {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing) {
            _context.Dispose();
        }

        // GET: Members
        public ActionResult Index() {
            // Eager Loading MembershipType, retrievd from DBContext
            var members = _context.Members.Include(c => c.GetMembershipType).ToList();
            return View(members);
        }
        // GET: Members/Details/<id> 
        public ActionResult Details(int id) {
            var member = _context.Members.SingleOrDefault(c => c.Id == id);
            if (member == null)
                return HttpNotFound();
            else
                return View(member);
        }
    }
}