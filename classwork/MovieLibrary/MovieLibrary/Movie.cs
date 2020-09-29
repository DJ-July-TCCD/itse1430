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

        //Feilds - location where data is stored in the class
        //string name
        //Feilds work identical to variables
        //Named as nouns, no abbreviations and no generic names
       public string Name = "";

       public string Description = "";
       public string Rating = "";
       public int RunLength;
       public bool Isclassic;
       public int ReleaseYear = 1900;


        //Functionaliuty - functions to be exposed

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
