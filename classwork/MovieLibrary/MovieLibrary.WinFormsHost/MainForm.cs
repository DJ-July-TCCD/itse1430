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

            toolStripMenuItem5.Click += OnMovieAdd;
        }

        private void OnMovieAdd (object sender, EventArgs e )
        {
            var form = new MovieForm();

            form.ShowDialog();
        }
    }
}
