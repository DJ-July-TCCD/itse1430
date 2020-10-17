using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MovieLibrary.WinFormsHost
{
    // class-declaration ::= [access] [modifiers] class identifier [ : T ]
    public partial class MovieForm : Form
    {
        //Access
        //Public - accessible in derived type
        //Protected - accessible in owning type and derived types
        //Private - only owning types

        //Methods : properties, methods
        //Virtual - base types provides base implementation, but can be overridden by a derived type.
        //Abstract - defined by base type but does not implement, derived types must override it.

        //Syntax
        // ctor-declaration ::= [access] T () { S* }
        public MovieForm () //: base()
        {
            //DO NOT CALL virtual members inside of constructors.
            InitializeComponent();
        }

        public MovieForm ( Movie movie ): this(movie, null)
        {
            //Movie = Movie;
        }

        //Constructor chaining - calling one constructor from another
        public MovieForm ( Movie movie, string title ) : this()
        {
            InitializeComponent();

            Movie = Movie;
            Text = title ?? "Add Movie";
        }

        public Movie Movie { get; set; }

        //Override indicates to compiler that you are overriding a virtual method
        protected override void OnLoad ( EventArgs e )
        {
            //Call the base member
            //this.OnLoad(e);
            base.OnLoad(e);

            if (Movie != null)
            {
                _txtName.Text = Movie.Name;
                _txtDescription.Text = Movie.Description;
                _comboRating.SelectedText = Movie.Rating;
                _chkIsclassic.Checked = Movie.IsClassic;
                _txtRunlength.Text = Movie.RunLength.ToString();
                _txtReleaseYear.Text = Movie.ReleaseYear.ToString();
            };

            // Go ahead and show validation errors
            ValidateChildren();
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
            // Force validation of all controls
            if (!ValidateChildren())
            {
                DialogResult = DialogResult.None;
                return;
            }
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
            Movie = movie;
            Close();
        }

        private int ReadAsInt32 ( Control control)
        {
            var text = control.Text;

            if (Int32.TryParse(text, out var result))
                return result;

            return -1;
        }

        private void OnValidateName ( object sender, CancelEventArgs e )
        {
            TextBox control = sender as TextBox;

            // Name is required
            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Name is required");
                e.Cancel = true;  // Not Validate
            } else
            {
                // Clear error from provider
                _errors.SetError(control, "");
            }
        }

        private void OnValidateRunLength ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            var value = ReadAsInt32(control);

            // Run Length >= 0
            if (value < 0)
            {
                _errors.SetError(control, "Run length must be greater than 0");
                e.Cancel = true;  // Not Validate
            } else
            {
                // Clear error from provider
                _errors.SetError(control, "");
            }
        }

        private void OnValidateReleaseYear ( object sender, CancelEventArgs e )
        {
            {
                var control = sender as TextBox;

                var value = ReadAsInt32(control);

                // Release Year >= 1900
                if (value < 1900)
                {
                    _errors.SetError(control, "Release year must be greater than 1900");
                    e.Cancel = true;  // Not Validate
                } else
                {
                    // Clear error from provider
                    _errors.SetError(control, "");
                }
            }
        }

        public void PlayWithObjects ( object value )
        {
            ///Common Type System (CTS) - one base type from which all other types derive
            // System.Object => object
            // string ToString () ::= Converts value to a string
            //  bool Equals ( object ) ::= Determines if the curretn instance equals another value
            // in GetHashCode ::= Returns and integral value representing the value

            var str = 10.ToString();
            var form = new Form();
            form.ToString();

            // Type Checking or casting
            // 1. C-Style cast ::=  (T)E
            //    Runtime attempts to to convert value to T and if successful returns value as T else crashes
            //    MUST be compile time validated
            string stringValue = (string)value;


            // 2. as- operator ::= E as T
            //   Runtime attempts to convert value to T adn if successful value as T else return null
            stringValue = value as string;
            if (stringValue != null )
            {  /* Dealign with string*/}


            // 3. is - operator ::= E is T
            //   At runtime, runtime verifies value is of the given T and returns true if successful or false otherwise
            var isString = value is string;  // true
            if (isString)
            {

                stringValue = (string)value;
            }

            // 4. Pattern Matching ::= E is T identifier
            //   Runtiem attempts to convert E to T and if succesful store in identifier, else stores in default(T)
            if (value is string sValue)
            {
                // string sValue = value as string
                // if (sValue != null)
            }

            // Dealing with null
            //   1. Let it fail - instance.ToString() // errors if null
            //   2. null coalescing - operator ::= E1 ?? E2
            //           if E1 is NOT null retirn E1 else returns E2
            stringValue = stringValue ?? "";

            // 3. null-conditioanl operator ::= E?.M
            //     E is an instance, M is any member, if E is not null then call M else skip it
            //     .ToString() -> string
            //     ?.ToString() -> string || null
            stringValue = stringValue?.ToString() ?? "";
            // if (stringValue!= null)
            //  var temp = stringValue.ToString()
            //   if (temp != null) return ""
            // return "";

            // 4. null-reference types
        }
    }
}


