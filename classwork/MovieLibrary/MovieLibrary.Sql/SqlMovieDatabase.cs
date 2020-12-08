using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MovieLibrary.Sql
{
    //ADO.NET
    // Provider specific types :: = (Provider)- 
    //      System.Data.(Provider)Client
    // Connection ::= Logical connection to a database
    // Command ::= Represents action to take (DML - data manipulation language) ( vs DDL - Data definition language)
    // Reader ::= Reads data as a stream
    // DataAdapter ::= REads data as a buffer
    // Transaction ::= Multiple commands
    public class SqlMovieDatabase : MovieDatabase
    {
        public SqlMovieDatabase ( string connectionString )
        {
            _connectionString = connectionString;
        }

        // Make read-only as it is only set in a constructor
        private readonly string _connectionString;
       // public Movie Add ( Movie movie, out string error )
       protected override Movie AddCore ( Movie movie)
        {
            using (var connection = OpenConnection())
            {
                // Provideer Agnostic way to create command
                var command = connection.CreateCommand();
                command.CommandText = "Add Movie";
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters
                //  1. Create parameter and add manually
                var parmName = new SqlParameter("@name", movie.Name);
                command.Parameters.Add(parmName);

                //  2. Create Parameter using command
                var parmDescription = command.CreateParameter();
                parmDescription.ParameterName = "@description";
                parmDescription.Value = movie.Description;
                parmDescription.SqlDbType = SqlDbType.NVarChar;
                command.Parameters.Add(parmDescription);

                //  3. (SQL Server) AddWithValue
                command.Parameters.AddWithValue("@rating", movie.Rating);
                command.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                command.Parameters.AddWithValue("@runLength", movie.RunLength);
                command.Parameters.AddWithValue("@isClassic", movie.IsClassic);

                // Execute commands
                //  ExecuteNonQuery ::= Returns ( or dont care about ) nothing - DELETE, UPDATE
                //  ExecuteScalar ::= Returns first value of first row ( if any ) - INSERT
                //  ExecuteReader ::= Returns results - STREAMING APPROACH
                object result = command.ExecuteScalar();
                var id = Convert.ToInt32(result);

                // Finish out method
                movie.Id = id;
                return movie;
            }
        }

        protected override void DeleteCore ( int id )
        {
            using (var connection = OpenConnection())
            {
                // Provider Agnostic way to create command
                var command = connection.CreateCommand();
                command.CommandText = "Delete Movie";
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters
                command.Parameters.AddWithValue("@id", id);

                // Execute commands
                //  ExecuteNonQuery ::= Returns ( or dont care about ) nothing - DELETE, UPDATE
                //  ExecuteScalar ::= Returns first value of first row ( if any ) - INSERT
                //  ExecuteReader ::= Returns results - STREAMING APPROACH
                command.ExecuteNonQuery();
            }
        }

        
        protected override  IEnumerable<Movie> GetAllCore ()
        {
            var ds = new DataSet();

            using (var connection = OpenConnection())
            {
                // Provider sprcific way 
                // Note: IDisposable but no exisiting implementation needs it
                var command = new SqlCommand("GetMovies", connection);
                command.CommandType = CommandType.StoredProcedure;



                //Excecute the command - using the buffered approach

                var da = new SqlDataAdapter() {
                    SelectCommand = command
                };

                // Retrieve Data (Buffered)
                da.Fill(ds);
            }

                // Get table (if any)
                var table = ds.Tables.Count > 0 ? ds.Tables[0] : null;
                if (table != null)
                {
                    //Enmumerate the rows
                    //Convert IEnumerable to IEnumerable<DataRow> using OfType()
                    //      foreach (var item in table.Items) { if (Item is DataRow row) yeild return row}
                    foreach (var row in table.Rows.OfType<DataRow>())
                    {
                        // Access fields
                        //Get specific column
                        // # - by ordinal (0 based index)
                        // name - by column name
                        //Get typed value
                        // Convert.ToInt32(row[#]) ::= Object to Int32
                        // row[].ToString() :: = To a string [PREFERRED]
                        yield return new Movie() {
                            Id = Convert.ToInt32(row[0]),
                            Name = row["name"].ToString(),

                            Description = row.IsNull("Description") ? null : row.Field<string>("Description"),
                            Rating = row.Field<string>("Rating"),

                            ReleaseYear = row.IsNull("ReleaseYear") ? 1900 : row.Field<int>("ReleaseYear"),
                            RunLength  = row.IsNull("RunLength") ? 0 : row.Field<int>("RunLength"),
                            IsClassic = row.Field<bool>("IsClassic"),
                        };
                    

                    }
                }            
        }

        protected override Movie GetByIdCore ( int id )
        {
            using (var connection = OpenConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = "GetMovie";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@id", id);

                // Stream data using reader
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var movieId = reader.GetInt32(0);
                        if (movieId == id)
                        {
                            // Read using either
                            //  Get(Primitive)
                            //  GetFieldValue<T>
                            // WARNING
                            //  Use ordinal - string column names require extra code
                            //      ** Boolean doesnt work
                            //      ** Null doesnt work
                            // var ordianl = reader.GetOrdinal("Name");
                            // reader.GEtString(ordinal)

                            // int? : nullable value type : can store null or value type
                            // int? nullableInt = 10;
                            // nullableInt = null;

                            return new Movie() {
                                Id = movieId,
                                Name = reader.GetString(1),
                                Description = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Rating = reader.GetFieldValue<string>(3),
                                ReleaseYear = reader.IsDBNull(4) ? 1900 : reader.GetFieldValue<int>(4),
                                RunLength = reader.IsDBNull(5) ? 0 : reader.GetFieldValue<int>(5),
                                IsClassic = reader.GetFieldValue<bool>(6)
                            };
                        }
                    }
                }
            }
            return null;
        }


        protected override void  UpdateCore ( int id, Movie movie )
        {
            using (var connection = OpenConnection())
            {
                // Provider Agnostic way to create command
                var command = connection.CreateCommand();
                command.CommandText = "Update Movie";
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters
                //  1. Create parameter and add manually
                var parmName = new SqlParameter("@name", movie.Name);
                command.Parameters.Add(parmName);

                //  2. Create Parameter using command
                var parmDescription = command.CreateParameter();
                parmDescription.ParameterName = "@description";
                parmDescription.Value = movie.Description;
                parmDescription.SqlDbType = SqlDbType.NVarChar;
                command.Parameters.Add(parmDescription);

                //  3. (SQL Server) AddWithValue
                command.Parameters.AddWithValue("@rating", movie.Rating);
                command.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                command.Parameters.AddWithValue("@runLength", movie.RunLength);
                command.Parameters.AddWithValue("@isClassic", movie.IsClassic);
                command.Parameters.AddWithValue("@id", id);

                // Execute commands
                //  ExecuteNonQuery ::= Returns ( or dont care about ) nothing - DELETE, UPDATE
                //  ExecuteScalar ::= Returns first value of first row ( if any ) - INSERT
                //  ExecuteReader ::= Returns results - STREAMING APPROACH
                command.ExecuteNonQuery();
            }
        }

        private SqlConnection OpenConnection()
        {
            var conn = new SqlConnection(_connectionString);

            //SqlException if something goes wrong
            conn.Open();
            return conn;
        }

        protected override Movie GetByName ( string name )
        {
            var movies = GetAllCore();
            //foreach (var movie in movies)
            //{
            //    if (String.Compare(movie.Name, name, true) == 0)
            //        return movie;
            //}
            //return null;

            //Delegate
            //PredicateDelegate predicate = MovieHasName;

            // Use Lambda method
            // 1. Using Directly
            // Func<Movie, bool> predicate = movie => MovieHasName(movie, name);

            // 2. Using Delegate
            //IEnumerable<Movie> filteredMovies = movies.Where(predicate);
            //var filteredMovies = movies.Where(movie => MovieHasName(movie, name));

            // 3. Use without method
            // Parameters on left provided by Where method call
            // Expression on right returned bu function 
            var filteredMovies = movies.Where(movie => String.Compare(movie.Name, name, true) == 0);

            // more complicated
            return null;
        }

        //delegate bool PredicateDelegate ( Movie movie, string name );
        //private bool MovieHasName ( Movie movie, string name)
        //{
        //    return String.Compare(movie.Name, name, true) == 0;
        //}
    }
}

