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
            toolStripMenuItem5.Click += OnMovieAdd;
            toolStripMenuItem7.Click += OnMovieDelete;

        }

        // Event - a noftifiaction to interested parties that something has happened

        private void OnMovieAdd (object sender, EventArgs e )
        {
            var form = new MovieForm();

            // Show Dialog - model :: =user must interact with child form, cannot access parent
            // Show - modeless ::= multiple windows open and accessible at all time
            form.ShowDialog(this); // Blcoks until form is dismissed

            // After Form is gone
            //TODO - Save Movie
            MessageBox.Show("Save Successful.");
        }

        private void OnMovieDelete ( object sender, EventArgs e )
        {
            //TODO : Verify Movie Exists

            //DialogResult
           switch (MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes: break;
                case DialogResult.No: return;
            };
        }
    }
}
