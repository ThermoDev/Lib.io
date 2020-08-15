using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lib.io.Models;

namespace Lib.io.Controllers {
    public class MembersController : Controller {
        // Temp Psuedo-Database
        public static IEnumerable<Member> members = new List<Member> {
                new Member {Id=0, Name = "Member 1" },
                new Member {Id=1, Name = "Member 2" }
            };
        // GET: Members
        public ActionResult Index() {
            return View(members);
        }

        public ActionResult Details(int id) {
            var member = members.SingleOrDefault(m => m.Id == id);
            if (member == null)
                return HttpNotFound();
            else
                return View(member);
        }
        //// GET: Members/ID
        //public ActionResult Index(int Id) {
        //    var members = new List<Member> {
        //        new Member { Name = "Member 1" },
        //        new Member { Name = "Member 2" }
        //    };

        //    return View(members);
        //}
    }
}