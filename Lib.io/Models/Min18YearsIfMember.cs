using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lib.io.Models {
    // Custom Validation Attribute
    public class Min18YearsIfMember : ValidationAttribute {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            var member = (Member)validationContext.ObjectInstance;
            // If member has not selected membership or is PAYG
            if (member.MembershipTypeId == MembershipType.Unknown || 
                member.MembershipTypeId == MembershipType.PayAsYouGo) {
                // Use static field to return succesful validation
                return ValidationResult.Success;
            }
            if (member.BirthDate == null) {
                // Instantiate new validation result to return an error
                return new ValidationResult("Birthdate is required.");
            }
            var age = DateTime.Today.Year - member.BirthDate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Member should be at least 18 years old to be on a membership.");

        }
    }
}