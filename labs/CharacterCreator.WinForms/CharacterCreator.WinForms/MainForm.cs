using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CharacterCreator.WinForms
{
    public partial class MainForm : Form
    {
        public MainForm ()
        {
            InitializeComponent();

            CharacterForm character;
            character = new CharacterForm();

            _lstCharacters = null;
            miCharacterAdd.Click += OnCharacterAdd;
            miCharacterDelete.Click += OnCharacterDelete;
            toolStripMenuItem7.Click += OnCharacterExit;
            miHelpAbout.Click += OnHelpAbout;
            miCharacterEdit.Click += OnCharacterEdit;
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutBox();

            about.ShowDialog(this);
        }

        private void OnCharacterExit ( object sender, EventArgs e )
        {
            Close();
        }
        private Character _character;

        private void OnCharacterAdd ( object sender, EventArgs e )
        {
            var form = new CharacterForm();

            var result = form.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            // SAVE MOVIE
            MessageBox.Show("Character Data Successfully Saved.");


        }

        private void OnCharacterDelete ( object sender, EventArgs e )
        {
            if (_character == null)
                return;

            switch(MessageBox.Show(this, "Are you sure you want to delete this character data?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes: break;
                case DialogResult.No: return;
            };

            _character = null;
        }

        private void OnCharacterEdit (object sender, EventArgs e )
        {
            if (_character == null)
                return;

            var form = new CharacterForm(_character, "Edit Character");

            var result = form.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            _character = form.Character;

            MessageBox.Show("Save Successful");
        }

        private void RefreshRoster()
        {
            _lstCharacters.DisplayMember = nameof(Character.Name);

            var roster = new BindingList<Character>();
            roster.Add(_character);

            _lstCharacters.DataSource = null;
            _lstCharacters.DataSource = roster;
        }
    }

}
