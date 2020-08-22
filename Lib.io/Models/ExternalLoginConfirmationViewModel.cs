using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lib.io.Models {
    public class ExternalLoginConfirmationViewModel {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Driver's License Number")]
        public string DriversLicense { get; set; }

        [Required]
        public string Phone { get; set; }

    }
}