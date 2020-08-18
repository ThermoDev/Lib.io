using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lib.io.Models;
using Lib.io.ViewModels;

namespace Lib.io.Controllers {
    public class MembersController : Controller {

        private ApplicationDbContext _context;

        public MembersController() {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing) {
            _context.Dispose();
        }

        public ActionResult New() {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new MemberViewFormModel {
                Member = new Member(),
                MembershipTypes = membershipTypes
            };
            return View("MemberForm", viewModel);
        }

        public ActionResult Edit(int id) {
            var member = _context.Members.SingleOrDefault(m => m.Id == id);
            if (member == null)
                return HttpNotFound();
            var viewModel = new MemberViewFormModel {
                Member = member,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("MemberForm", viewModel);
        }


        // Model-Binding that is fetched from request data
        // Validates the Anti-Forgery Token provided by the members form.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Member member) {
            if (!ModelState.IsValid) {
                var viewModel = new MemberViewFormModel {
                    Member = member,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("MemberForm", viewModel);
            }

            if (member.Id == 0) {
                _context.Members.Add(member);
            }
            else {
                var memberInDb = _context.Members.Single(m => m.Id == member.Id);

                memberInDb.Name = member.Name;
                memberInDb.BirthDate = member.BirthDate;
                memberInDb.MembershipTypeId = member.MembershipTypeId;
                memberInDb.IsSubscribedToNewsletter = member.IsSubscribedToNewsletter;
                
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Members");
        }

        // GET: Members
        public ActionResult Index() {
            // Eager Loading MembershipType, retrievd from DBContext
            var members = _context.Members.Include(m => m.MembershipType).ToList();
            return View(members);
        }
        // GET: Members/Details/<id> 
        public ActionResult Details(int id) {
            var member = _context.Members.Include(m => m.MembershipType).SingleOrDefault(m => m.Id == id);
            if (member == null)
                return HttpNotFound();
            else
                return View(member);
        }
    }
}