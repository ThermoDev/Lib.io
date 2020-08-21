using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lib.io.Dtos {
    public class MembershipTypeDto {
        public byte Id { get; set; }
        public String Name { get; set; }
        public byte DiscountRate { get; set; }
    }
}