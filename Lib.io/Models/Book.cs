using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lib.io.Models {
    public class Book {
        // POCO - Plain Old CLR(Common Language Runtime) Objects
        // Objects represents the state
        public int Id { get; set; } 
        public String Name { get; set; }
    }
}