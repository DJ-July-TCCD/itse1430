using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieLibrary
{
    // ABstract Class required if ANY member is abstract
    //  1. Cannot be instantiated
    //  2. Must Derive from it
    //  3. Must implement all abstract members
    public abstract class MovieDatabase : IMovieDatabase
    {
        // Default constructor to seed database
        protected MovieDatabase ()
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
            foreach (var item in items)
                Add(item, out var error);


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

        public void Foo () { }

        // Array - T[] = type name followed with square brackets
        public Movie Add ( Movie movie, out string error )
        {
            var results = new ObjectValidator().TryValidateFullObject(movie);
            if (results.Count() > 0)
            {
                foreach (var result in results)
                {
                    error = result.ErrorMessage;
                    return null;
                }
            }
            //TODO Movie is valid, name is unique
            var existing = FindByName(movie.Name);
            if (existing != null)
            {
                error = "MOvie must be unique!";
                return null;
            }

            error = null;
            return AddCore(movie);
        }

        protected abstract Movie AddCore ( Movie movie );

        protected virtual Movie FindByName ( string name )
        {
            foreach(var movie in GetAll())
            {
                if (String.Compare(movie.Name, name, true) == 0)
                    return movie;
            }
            return null;
        }

        public void Delete ( int id )
        {
            var movie = GetById(id);
            if (movie != null)
            {
                // Must use teh saem instacne that is stored in teh line so ref equality works
                _movies.Remove(movie);
            }

            //for (var index = 0; index < _movies.Length; ++index)
            //{
            //    // Array element access ;;= V[int]
            //    //if (_movies[index] != null && _movies[index].Id == id)
            //    if (_movies[index]?.Id == id) // null conditional  ?.  If instance != null access the member
            //    {
            //        _movies[index] = null;
            //        return;
            //    }
            //}
        }

        // Use IEnumerable<T> for read-only lists of items
        //public Movie[] GetAll ()
        public IEnumerable<Movie> GetAll ()
        {
            // DONT Do THIS
            // 1. Expose underlying movie items
            // 2. Callers can add/remove movies
            //return _movies;

            // Foreach equivalent
            // var enumerator = _movies.GetEnumerator();
            // while (enumerator.Next())
            // {
            // var movie = enumerator.Current;
            //  S*
            // }
            //var items = new Movie[_movies.Count];
            //var index = 0;

            // iterator IENumerable<T>
            //yield return T
            foreach (var movie in _movies)
                //items[index++] = CloneMovie(movie);  // relies on the IEnumerator<T>
                yield return CloneMovie(movie);
            ;

            //return items;
        }

        public Movie Get ( int id )
        {
            var movie = GetById(id);

            // CLone Movie if we found it 
            return (movie != null) ? CloneMovie(movie) : null;
        }

        private Movie GetById ( int id )
        {
            // foreach (var id in array) S
            //for (var index = 0; index < _movies.Length; ++index)
            foreach (var movie in _movies)
            {
                // Restrctions:
                // 1. Movie is Read Only
                // 2. _movies(array) cannot change, immutable 
                if (movie?.Id == id)
                    return movie;
            }

            return null;
        }

        public string Update ( int id, Movie movie )
        {
            //Validate ID
            // Movie exists
            var existing = GetById(id);
            if (existing == null)
                return "Movie not found";

            // Updaated Movie is Valid
            // updated Movie has a Unique Name
            CopyMovie(existing, movie);

            //for (var index = 0; index < _movies.Length; ++index)
            //{

            //    if (_movies[index]?.Id == id) // null conditional  ?.  If instance != null access the member
            //    {
            //        // Clone it so we can seperate aour value from argument
            //        var item = CloneMovie(movie);


            //        item.Id = id;
            //        _movies[index] = movie;
            //        return  "";
            //    }
            //}

            return "";
        }
        



        //Non-generic
        //   ArrayList - list of objects (lose strong typing known to C#)
        // Generic Types
        //   List<T> : where T equals any type 
    }


}

