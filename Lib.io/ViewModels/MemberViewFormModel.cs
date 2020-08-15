using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lib.io.Models;

namespace Lib.io.ViewModels {
    public class MemberViewFormModel {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Member Member { get; set; }
    }
}