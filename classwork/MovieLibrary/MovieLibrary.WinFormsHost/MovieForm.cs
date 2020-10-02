using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MovieLibrary.WinFormsHost
{
    public partial class MovieForm : Form
    {
        public MovieForm ()
        {
            InitializeComponent();
        }

        private void OnCancel ( object sender, EventArgs e )
        {
            Close();
        }

        //Event Handler - handles an event
        // This method is handling the button's Click event
        // Always has a void return type - (object sender, EventArgs e)
        private void OnSave ( object sender, EventArgs e )
        {
            // I want the button that was clicked
            // Type Casting 
            // WRONG = var button = (Button)sneder;  // C-style cast - crashes if wrong
            // var str = (string)10;
            // CORRECT: var button = sender as Button;  // as operator - always safe return typed version or null
            var button = sender as Button;
            if (button == null)
                return;


            var movie = new Movie();
            movie.Name = _txtName.Text;
            movie.Description = _txtDescription.Text;
            movie.Rating = _comboRating.SelectedText;
            movie.IsClassic = _chkIsclassic.Checked;

            movie.RunLength = ReadAsInt32(_txtRunlength);  //this.ReadAsInt32
            movie.ReleaseYear = ReadAsInt32(_txtReleaseYear);

            var error = movie.Validate();
            if (!String.IsNullOrEmpty(error))
            {
                //Show error message - use for standard messages
                MessageBox.Show(this, error, "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            };

            //TODO: Return Movie
            Close();
        }

        private int ReadAsInt32 ( Control control)
        {
            var text = control.Text;

            if (Int32.TryParse(text, out var result))
                return result;

            return -1;
        }
    }
}
