/*
*ITSE 1430
*Delendrick July
*Classwork
 */
using System;

//String Builder, Reguler Expression, Encoding
//using System.Text;

namespace MovieLibrary
{
    //Type
    //Pascal Case
    //Noun or Noun-like objects
    //Singular unless representing a collection


    public class Movie
    {

        //Data - data to store

        //Fields - location where data is stored in the class
        // should always be private
        // Camel-cased named always and start with underscore
        //string name
        //Feilds work identical to variables
        //Named as nouns, no abbreviations and no generic names

        //Only time publoc fields allowed - read only data
        // [access] const T indentifier = E;
        // 1. Must be a primitive type
        // 2. Must have an initializer expression
        // 3. Must recompile all code if changed
        public const int MaximumNameLength = 50;

        // Read Only
        // [access] readonly T indenttifier;
        // 1. Any type
        // 2. Must be initialized once in intializer expression or at instance creation
        // 3. Allowed to have different read only values fro each instacne
        // 4. Not baked into source code
        public readonly int MaximumDesdcriptionLength = 200;
        private string _name = "";

        private string _description = "";
        private string _rating = "";
        
        
        

        // Not a field because:
        // 1. Can not write 
        // 2.Calculated Value
        //public int Age;

        //Not a method either due to,
        // 1. Not functionality
        // 2. Complex syntax
        // 3. Get/Set in the title - shouldn't be a method; should be a field
        //public int GetAge () { }
        public int Age
        {
            //Calculated property
            //Read-only property
            get { return DateTime.Now.Year - ReleaseYear; }
            //set { }
        }

        // Mixed accessibility - use of different access on either getter or setter
        // 1. Only 1 method can have accesss modifier
        // 2. Always more restricitive
        public int Id { get; private set; } // Reads from teh public class, writes to the private


        // Properties - methods that have field-like syntax
        // full  property = [access] - type, identifier {getter setter}
        // getter ::= get {S*}, must have a return value that matches the property
        // setter ::= set{S*}
        // auto - property :: = [access] T identifier {get; set;}
        // *Properties returning arrays or strings shoudl not return null
        public string Name
        {
            // getter - Always starts with get and has {}, T get_Name ()
            get
            {
                // Null Coalesce - scanning a series of expressions looking for non-NULL
                // E1 ?? E2
                // if E1 is not null then return E1
                // else return E2

                //if (_name == null)
                //    return "";
                // return _name;

                return _name ?? "";
            }


            // setter - Always starts with set and has {}, void set_Name ( T value )
            set {
                _name = value;
            }
        }

        /// <summary> Gets or sets the movie description. </summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value; }
        }

        public string Rating
        {
            get { return _rating ?? ""; }
            set { _rating = value; }
        }

        /// <summary> Gets or sets the run length in minutes.</summary>
        public int RunLength { get; set; }
        //{
        //    get { return _runLength; }
        //    set { _runLength = value; }
        //}
        //private int _runLength;

        /// <summary>  Gets or sets release year. </summary>
        /// <value> Default value is set to 1900. </value>
        public int ReleaseYear { get; set; } = 1900;
        //{
        //    get { return _releaseYear; }
        //    set { _releaseYear = value; }
        //}
        //private int _releaseYear = 1900;

        public bool IsClassic { get; set; }
        //{
        //    get { return _isclassic; }
        //    set { _isclassic = value; }
        //}
        //private bool _isclassic;



        //Functionality - functions to be exposed

        /// <summary> Validates the movie instance. </summary>
        /// <returns> Error message, if any. </returns>
        public string Validate ()
        {
            //Name is required
            if (String.IsNullOrEmpty(Name))
                return "Name is Required";

            //Run length is required
            if (RunLength < 0)
                return "Run Length must be greater than or equal to 0";

            //Release Year must be >= 1900
            if (ReleaseYear < 1900)
                return "Release Year must be at least 1900";

            return null;
        }
    }
}
