using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary
{
   
    public class MovieDatabase
    {
        // Array - T[] = type name followed with square brackets
        public Movie Add ( Movie movie, out string error )
        {
            //TODO Movie is valid, name is unique
            error = "";
            // Find first empty spot in array 
            // for (E1; EC; EU) S:
            //     E1 ::= initializer expression (runs once before loops excecutes)
            //     EC ::= conditonal expression => boolean ( execcutes before loop statement is run, aborts if condition is false)
            //     EU ::= update expression (runs at end of current iteration)
            // Length -> int(number of rows in array)
            for (var index = 0; index < _movies.Length; ++index)
            {
                // Array element access ;;= V[int]
                if (_movies[index] == null)
                {
                    // Close so argument can be modified without impacting the array
                    var item = CloneMovie(movie);

                    // Set a unique ID
                    item.Id = _id++;

                    // Add movie to array 
                    _movies[index] = movie;

                    // Set ID on original and return
                    movie.Id = item.Id;
                    return movie;
                }
            }

            error = "No more room";
            return null;

            // TODO : No more room for movies
        }

        public void Delete ( int id )
        {
          
            for (var index = 0; index < _movies.Length; ++index)
            {
                // Array element access ;;= V[int]
                //if (_movies[index] != null && _movies[index].Id == id)
                if (_movies[index]?.Id == id) // null conditional  ?.  If instance != null access the member
                {
                    _movies[index] = null;
                    return;
                }
            }
        }
        public Movie[] GetAll ()
        {
            // DONT Do THIS
            // 1. Expose underlying movie items
            // 2. Callers can add/remove movies
            //return _movies;

            //TODO: Determine how many movies we're storing
            // Determine how many movies we're storing 
            // fo reach one create a clones copy

            return _movies;
        }

        public Movie Get ( int id )
        {
            // foreach (var id in array) S
            //for (var index = 0; index < _movies.Length; ++index)
            foreach(var movie in _movies)
            {
                // Restrctions:
                // 1. Movie is Read Only
                // 2. _movies(array) cannot change, immutable 
                if (movie?.Id == id)
                
                    return CloneMovie(movie);
            }

            return null;
        }

        public string Update ( int id, Movie movie )
        {
            //Validate ID
            // Movie exists
            var existing = Get(id);
            if (existing == null)
                return "Movie not found";

            // Updaated Movie is Valid
            // updated Movie has a Unique Name
            for (var index = 0; index < _movies.Length; ++index)
            {

                if (_movies[index]?.Id == id) // null conditional  ?.  If instance != null access the member
                {
                    // Clone it so we can seperate aour value from argument
                    var item = CloneMovie(movie);


                    item.Id = id;
                    _movies[index] = movie;
                    return  "";
                }
            }

            return "";
        }

        private Movie CloneMovie (Movie movie)
        {
            var item = new Movie();
            item.Id = movie.Id;
            item.Name = movie.Name;
            item.Rating = movie.Rating;
            item.ReleaseYear = movie.ReleaseYear;
            item.RunLength = movie.RunLength;
            item.IsClassic = movie.IsClassic;
            item.Description = movie.Description;

            return item;
        }
        private Movie[] _movies = new Movie[100]; // 0 - 99
        private int _id = 1;
    }
    

}

