using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Lib.io.Models;

namespace Lib.io.Dtos {
    public class MemberDto {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }


        // Don't add MembershipType here, as it couples this DTO to our Domain Object
        // Instead, create a new DTO for MembershipType
        public MembershipTypeDto MembershipType { get; set; }

        // [Min18YearsIfMember]
        public DateTime? BirthDate { get; set; }
    }
}