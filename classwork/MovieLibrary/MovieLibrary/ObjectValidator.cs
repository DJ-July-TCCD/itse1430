using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieLibrary
{
    // Static Class
    // Cannot be instaniated
    // Cannot contain instance memebers
    // Holders for Static Helper Methods
   public static class ObjectValidator
   {
        // Make static beacuse it doesn't use any instance data
        public static IEnumerable<ValidationResult> TryValidateFullObject ( IValidatableObject value )
        {
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(value, new ValidationContext(value), validationResults, true);

            return validationResults;
        }

        public static void ValidateFullObject ( IValidatableObject value )
        {
            Validator.ValidateObject(value, new ValidationContext(value), true);

        }
    }
}
