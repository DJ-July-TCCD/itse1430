using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary
{
    public static class SeedMovieDatabase
    {
        // Make static beacuse it does not reference ant inastance data
        // nor does it reall need to be created
        public static void Seed ( IMovieDatabase database )
        {
            {
                // Not needed here
                // _movies.Clear();

                //Collection initializer syntax
                var items = new[] {
                new Movie() {
                 Name = "Titanic",
                 ReleaseYear = 1997,
                 RunLength = 195,
                 Description = "Film about a sinking boat.",
                 IsClassic = true,
                 Rating = "PG-13",
                },


            new Movie() {
                Name = "Fast and Furious",
                ReleaseYear = 2009,
                RunLength = 106,
                Description = "Film about racing cars",
                IsClassic = true,
                Rating = "PG-13",
            }
            };

                // TODO: Fix error Handling
                foreach (var item in items)
                    database.Add(item);


                // Seed Database
                // Object Initializer - only usuable on new operator
                // Limitations
                // 1). Con only set properties with setters
                // 2). Can set properties that are themselves new'd up, but cannot set child properties
                //                        Position = new Position() { Name = "Boss"};  // Allowed
                //                        Position.Title = "Boss";   // Not allowed
                // 3). Properties cannot rely on other properties
                //                     Description = "blah"
                //                     FullDescription = Description
                //var movie = new Movie();
                //movie.Name = "Titanic";
                //movie.ReleaseYear = 1997;
                //movie.RunLength = 195;
                //movie.Description = "Film about a sinking boat.";
                //movie.IsClassic = true;
                //movie.Rating = "PG-13";
                //Add(movie, out var error);
                //    var movie = new Movie() {
                //        Name = "Titanic",
                //        ReleaseYear = 1997,
                //        RunLength = 195,
                //        Description = "Film about a sinking boat.",
                //        IsClassic = true,
                //        Rating = "PG-13",
                //    };
                //    Add(movie, out var error);


                //    movie = new Movie() {
                //        Name = "Fast and Furious",
                //        ReleaseYear = 2009,
                //        RunLength = 106,
                //        Description = "Film about racing cars",
                //        IsClassic = true,
                //        Rating = "PG-13",
                //};
                //    Add(movie, out error);
            }
        }

    }
}
