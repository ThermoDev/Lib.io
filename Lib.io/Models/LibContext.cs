using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Lib.io.Models {
    public class LibContext : DbContext {

        public LibContext() {

        }

        //Entities
        public DbSet<Member> Members { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
