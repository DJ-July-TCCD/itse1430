/*
*ITSE 1430
*Delendrick July
*Classwork
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

//String Builder, Reguler Expression, Encoding
//using System.Text;

namespace MovieLibrary.WedHost.Models
{

    public class MovieModel //: IValidatableObject
    {
        public int Id { get; set; }

        // Attributes are Metadata
        // [][] || [,] - Multiple Attributes
        // Required - value cannot be null
        // Attributes may be limited to certain types or members
        
       // [RequiredAttribute()] - Paren are needed if constructor value needs to be set
      // [RequiredAttribute] - Attribute is also optional
      [Required(AllowEmptyStrings = false)]
      [StringLength(Movie.MaximumNameLength)]
        public string Name { get; set; }

       
        [StringLength(Movie.MaximumNameLength)]
        public string Description { get; set; }

        public string Rating { get; set; }
        
        // Rnge enforces min / max value ; Range must be specified
        // Limited to - doubles, int, arbitrary types represented as strings
        [Range(0, Int32.MaxValue, ErrorMessage = "Run Length must be greater than or equal to 0.")]
        public int RunLength { get; set; }
       
        [Range(1900, 2100)]
        public int ReleaseYear { get; set;}
        
        public bool IsClassic { get; set; }
    }
}
