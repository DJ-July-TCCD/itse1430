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
        private Movie[] _movies;
        private readonly object form;

        private void AddMovie ( Movie movie )
        {
            MessageBox.Show("NOt implemented yet");
        }

        private void DeleteMovie ( Movie movie )
        {
            MessageBox.Show("Not implemented yet");
        }

        private void EditMovie ( Movie movie )
        {
            MessageBox.Show("NOt implemented yet");
        }

        private Movie GetSelectedMovie ()
        {
            return null;
        }

            private void RefreshUI ()
            {
            _lstMovies.DisplayMember = nameof(Movie.Name);

            _lstMovies.DataSource = null;
            _lstMovies.DataSource = _movies;

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
            switch (MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes: break;
                case DialogResult.No: return;
            };

            DeleteMovie(movie);
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



        }
    }
}
