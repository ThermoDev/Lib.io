using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lib.io.Models;

namespace Lib.io.ViewModels {
    public class RandomBookViewModel {
        public Book Book { get; set; }
        public List<Member> Members { get; set; }
    }
}