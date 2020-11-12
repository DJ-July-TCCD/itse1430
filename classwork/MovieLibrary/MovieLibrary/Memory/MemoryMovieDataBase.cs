using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary.Memory
{

    public class MemoryMovieDatabase : MovieDatabase
    {
       // public Movie Add ( Movie movie, out string error )
       protected override Movie AddCore ( Movie movie)
        {
            // Close so argument can be modified without impacting the array
            var item = CloneMovie(movie);

            // Set a unique ID
            item.Id = _id++;

            // Add movie to array 
            //_movies[index] = movie;
            _movies.Add(item);

            // Set ID on original and return
            movie.Id = item.Id;
            return movie;
        }

        protected override void DeleteCore ( int id )
        {
            var movie = FindById(id);
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

        
        protected override  IEnumerable<Movie> GetAllCore ()
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

        protected override Movie GetByIdCore ( int id )
        {
            var movie = FindById(id);

            // Clone Movie if we found it 
            return (movie != null) ? CloneMovie(movie) : null;
        }

        private Movie FindById ( int id )
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

        protected override void  UpdateCore ( int id, Movie movie )
        {

            var existing = FindById(id);
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
        }

        private Movie CloneMovie ( Movie movie )
        {
            var item = new Movie();
            item.Id = movie.Id;

            CopyMovie(item, movie);

            return item;
        }

        private void CopyMovie ( Movie target, Movie source )
        {
            target.Name = source.Name;
            target.Rating = source.Rating;
            target.ReleaseYear = source.ReleaseYear;
            target.RunLength = source.RunLength;
            target.IsClassic = source.IsClassic;
            target.Description = source.Description;
        }
        private List<Movie> _movies = new List<Movie>();  
        private int _id = 1;

        protected override Movie GetByName ( string name )
        {
            foreach (var movie in _movies)
            {
                if (String.Compare(movie.Name, name, true) == 0)
                    return CloneMovie(movie);
            }
            return null;
        }




    }


}

