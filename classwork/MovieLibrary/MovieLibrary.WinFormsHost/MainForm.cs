using System;    //DO NOT DELETE
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieLibrary.WinFormsHost
{
    public partial class MainForm : Form
    {
        public MainForm ()
        {
            InitializeComponent();

            Movie movie;
            movie = new Movie();  //Create an instance ::= new T()

            //var movie2 = new Movie();  //new instance

            //Member access operator ::= E . M
            movie.Name = "Titanic";

            // Hooks up Event Handler to an event
            // Event += method 
            // Event -= method  : detach
            _miMovieAdd.Click += OnMovieAdd;
            _miMovieEdit.Click += OnMovieEdit;
            _miMovieDelete.Click += OnMovieDelete;
            _miHelpAbout.Click += OnHelpAbout;

        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutBox();

            about.ShowDialog(this);
        }

        // Event - a noftifiaction to interested parties that something has happened

        // Array - T[] Array of movies
        //  Instantiate - ::=  new T[E1]
        //  Index : 0 to size -1 
        private MovieDatabase _movies = new MovieDatabase();
        //private Movie[] _movies = new Movie[100]; // 0 - 99
       // private Movie[] _emptyMovies = new Movie[0];  // empty array are equivelant so use empty arrays instead of null

        private void AddMovie ( Movie movie )
        {
           var newMovie =  _movies.Add(movie, out var message);
            if(newMovie == null)
            {
                MessageBox.Show(this, message, "Add Failed.", MessageBoxButtons.OK);
                return;
            }

            RefreshUI();
            //// Find first empty spot in array 
            //// for (E1; EC; EU) S:
            ////     E1 ::= initializer expression (runs once before loops excecutes)
            ////     EC ::= conditonal expression => boolean ( execcutes before loop statement is run, aborts if condition is false)
            ////     EU ::= update expression (runs at end of current iteration)
            //// Length -> int(number of rows in array)
            //for (var index = 0; index < _movies.Length; ++index)
            //{
            //    // Array element access ;;= V[int]
            //    if (_movies[index] == null)
            //    {
            //        // Add omvie to array 
            //        _movies[index] = movie;   // Movie is a ref type thus movie and _movies[index] reference the same instance
            //        return;
            //    }
            //}

            //MessageBox.Show(this, "No more room for movies", "Add Failed", MessageBoxButtons.OK);
        }

        private void DeleteMovie ( int id )
        {
            _movies.Delete(id);
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

        private void EditMovie ( int id, Movie movie )
        {
            var error = _movies.Update(id, movie);
            if(String.IsNullOrEmpty(error))
            {
                RefreshUI();
                return;
            }
            //for (var index = 0; index < _movies.Length; ++index)
            //{

            //    if (_movies[index]?.Id == id) // null conditional  ?.  If instance != null access the member
            //    {
            //        // Because we are doing this in memory
            //        movie.Id = id;
            //        _movies[index] = movie;
            //        return;
            //    }
            //}

            MessageBox.Show(this, "Cannot find movie", "Edit Movie", MessageBoxButtons.OK);
        }

        private Movie GetSelectedMovie ()
        {
            return _lstMovies.SelectedItem as Movie;

        }

        private void RefreshUI ()
        {
            //_lstMovies.DisplayMember = nameof(Movie.Name);

            _lstMovies.DataSource = null;
            _lstMovies.DataSource = _movies.GetAll();
        }

        private void OnMovieAdd (object sender, EventArgs e )
        {
            var form = new MovieForm();

            // Show Dialog - model :: =user must interact with child form, cannot access parent
            // Show - modeless ::= multiple windows open and accessible at all time
            var result = form.ShowDialog(this); // Blocks until form is dismissed
            if (result == DialogResult.Cancel)
                return;

            //Save Movie
            AddMovie(form.Movie);
        }

        private void OnMovieDelete ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            //DialogResult
            switch (MessageBox.Show(this, $"Are you sure you want to delete '{movie.Name}' ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes: break;
                case DialogResult.No: return;
            };

            DeleteMovie(movie.Id);
            RefreshUI();
        }
        private void OnMovieEdit ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            //Object Creation
            // 1. Allocate memory for instance, zero initialized
            // 2. Initialize fields
            // 3. Constructor - method on class to complete the initialization
            // 4. Return new insitance
            var form = new MovieForm(movie, "Edit Movie");
            // form.Movie = _movie;

            var result = form.ShowDialog(this); //  Block until form is dismissed
            if (result == DialogResult.Cancel)
                return;

            EditMovie(movie.Id, form.Movie);

        }
    }
}
