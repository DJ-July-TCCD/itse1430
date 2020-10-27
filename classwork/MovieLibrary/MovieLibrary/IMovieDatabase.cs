using System;
using System.Collections.Generic;

namespace MovieLibrary
{
    // Interface - declaration ::= [access] interface indentifier { interface-member }
    //             interface-member ::= property, methid or event
    //                 1). No access modifiers (always public)
    //                 2). No implementation of anything
    //   Cannot instantiate an interface
    public interface IMovieDatabase
    {
        Movie Add ( Movie movie, out string error );
        void Delete ( int id );
        Movie Get ( int id );
        IEnumerable<Movie> GetAll ();
        string Update ( int id, Movie movie );
    }
}