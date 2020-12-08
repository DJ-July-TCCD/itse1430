using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace MovieLibrary.IO
{


    public class FileMovieDatabase : MovieDatabase
    {

        public FileMovieDatabase ( string filename )
        {
            _filename = filename;
        }

        private readonly string _filename;
        // public Movie Add ( Movie movie, out string error )
        protected override Movie AddCore ( Movie movie )
        {
            var movies = GetAllCore();

            //movies.Count()
            // .Any() -> true if there are any items in set or falseotherwise
            // .Max() => returns largest item, but crashes if set is empty
            // .Union => combines two sets of data after enumerating through the first set
            var lastId = movies.Any() ? movies.Max(x => x.Id) : 0;

            //// HACK: to list
            //var items = new List<Movie>(movies);

            //var lastId = 0;
            //foreach (var item in movies)
            //{
            //    if (item.Id > lastId)
            //        lastId = item.Id;
            //}

            // Set a unique ID
            movie.Id = ++lastId;

            // Add a new items ro the existing IEnumerable
            movies.Union(new[] { movie });
           // items.Add(movie);

            SaveMovies(movies);
            return movie;
        }

        protected override void DeleteCore ( int id )
        {
            // Streaming Approach
            //StreamWriter writer = null;

            var tempFileName = _filename + ".bak";
            // Stream OG File contents to temp files, excluding deleted movies
            // try
            // USING STATEMENT - not declaration
            //      Statement wraps code that requires cleanup
            //      Using(E) S
            //      E - type IDisposeable
            // IDisposable - interface that identifies a type as needing explicit cleanup

            // open OG file for reading
            using (Stream stream = File.OpenRead(_filename))
            using (var reader = new StreamReader(stream)) 
            {
                // Open file for reading
                // OpenWrite(filename) - opens file for writing
                // OpenText(filename) - opens file for reading
                // Stream - series of data ( binary - byte, text = character)
                //      May be read, write or seek ( CanRead, CanWrite, CanSeek)
                //stream.Read() - low-level

                
                // Open temp file for writing - overwrite any existing file
                using (var writer = new StreamWriter(tempFileName, false)) 
                {
                    // keep reading until end of stream
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var movie = LoadMovie(line);

                        // If not the movie we're looking for, write out line to temp file
                        if (movie?.Id != id)
                            writer.WriteLine(line);
                    }

                }
                // NOT exception safe
                //stream.Close();, reader.Close();
            }
           // } finally
           // {
           //     writer?.Close();

           //     //Guaranteed to be called whether code completes or not
           //     stream.Close();
           // }

            // Swap temp file with OG file
            // LOcation File, Destination File, Exception prevention
            File.Copy(tempFileName, _filename, true);
            File.Delete(tempFileName);

            // Buffered Apporach
            //var movies = new List<Movie>(GetAllCore());
            //foreach (var movie in movies)
            //{
            //    if (movie.Id == id)
            //    {
            //        movies.Remove(movie);
            //        break;
            //    }
            //}

            //SaveMovies(movies);
        }


        protected override IEnumerable<Movie> GetAllCore ()
        {
            if (File.Exists(_filename))
            {
                //// Read File buffered as array
                //var lines = File.ReadAllLines(_filename);
                //foreach (var line in lines)
                //{
                //    var movie = LoadMovie(line);
                //    if (movie != null)
                //        yield return movie;
                //}
                //var movies = File.ReadAllLines(_filename)
                //                 .Select(x => LoadMovie(x));

                //foreach (var movie in movies)
                //{
                //    yield return movie;
                //}

                // LINQ syntax
                var movies = from line in File.ReadAllLines(_filename)
                             where !String.IsNullOrEmpty(line)
                             //orderby member, member
                select LoadMovie(line);

                foreach (var movie in movies)
                    yield return movie;
            }
        }

        protected override Movie GetByIdCore ( int id )
        {
            return FindById(id);
        }

        private Movie FindById ( int id )
        {
            // Streaming Approach
            Stream stream = File.OpenRead(_filename);
            try
            {
                // Open file for reading
                // OpenWrite(filename) - opens file for writing
                // OpenText(filename) - opens file for reading
                // Stream - series of data ( binary - byte, text = character)
                //      May be read, write or seek ( CanRead, CanWrite, CanSeek)
                //stream.Read() - low-level
                StreamReader reader = new StreamReader(stream); // Reads Text Stream
                                                                // BinaryReader reader;

                // keep reading until end of stream or movie
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    var movie = LoadMovie(line);
                    if (movie?.Id == id)
                        return movie;
                }
                return null;

                // NOT exception safe
                //stream.Close();
            } finally
            {
                // Exception safe
                //Guaranteed to be called whether code completes or not
                stream.Close();
            }
           
            // Buffered Apporach
            //var movies = GetAllCore();
            //foreach (var movie in movies)
            //{

            //    if (movie?.Id == id)
            //        return movie;
            //}

            //return null;
        }

        protected override void UpdateCore ( int id, Movie movie )
        {
            //// Remove Old Movie
            //var items = new List<Movie>(GetAllCore());
            //foreach (var item in items)
            //{
            //    if (item.Id == id)
            //    {
            //        // Must use item here not movie
            //        items.Remove(item);
            //        break;
            //    }
            //}

            //// Add New Movie
            //movie.Id = id;
            //items.Add(movie);
            var items = GetAllCore();
            var existing = items.FirstOrDefault(x => x.Id == id);
            if (existing != null)
            {
                // Exclude the existing movie
                items = items.Except(new[] { existing })
                             .Union(new[] { movie });
                SaveMovies(items);
            }


            // .Except => return all items in first list, excpet items in second
            //      Uses equality exception
        }

        private Movie LoadMovie ( string line )
        {
            // NO COMMAS in string values

            // Id, "Name", "Description", "Rating", RunLength, Realease Year, IsClassic

            string[] tokens = line.Split(',');
            if (tokens.Length != 7)
                return null;

            var movie = new Movie() {
                Id = Int32.Parse(tokens[0]),
                Name = RemoveQuotes(tokens[1]),
                Description = RemoveQuotes(tokens[2]),
                Rating = RemoveQuotes(tokens[3]),
                RunLength = Int32.Parse(tokens[4]),
                ReleaseYear = Int32.Parse(tokens[5]),
                IsClassic =  Int32.Parse(tokens[6]) != 0,
            };

            return movie;
        }

        private string EncloseQuotes ( string value )
        {
            return "\"" + value + "\"";
        }

        private string RemoveQuotes ( string value )
        {
            return value.Trim('"');
        }


        protected override Movie GetByName ( string name )
        {
            var movies = GetAllCore();
            foreach (var movie in movies)
            {
                if (String.Compare(movie.Name, name, true) == 0)
                    return movie;
            }
            return null;
        }

        private void SaveMovies ( IEnumerable<Movie> movies)
        {
            var lines = new List<string>();
            foreach (var movie in movies)
                lines.Add(SaveMovie(movie));

            File.WriteAllLines(_filename, lines);
        }
        private string SaveMovie ( Movie movie )
        {
            // NO COMMAS in string values

            // Id, "Name", "Description", "Rating", RunLength, Realease Year, IsClassic
            var builder = new System.Text.StringBuilder();

            builder.AppendFormat($"{movie.Id},");
            builder.AppendFormat($"{EncloseQuotes(movie.Name)},");
            builder.AppendFormat($"{EncloseQuotes(movie.Description)},");
            builder.AppendFormat($"{EncloseQuotes(movie.Rating)},");
            builder.AppendFormat($"{movie.RunLength},");
            builder.AppendFormat($"{movie.ReleaseYear},");
            builder.AppendFormat($"{(movie.IsClassic ? 1 : 0)}");

            return builder.ToString();
        }



    }

}

