using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CharacterCreator.WinForms
{
    public partial class CharacterForm : Form
    {
        public CharacterForm ()
        {
            InitializeComponent();
         
        }

        public CharacterForm ( Character character ) : this(character, null)
        {
            Character = character;
        }

        public CharacterForm ( Character character, string Name ) : this()
        {
            Character = character;
            Text = Name ?? "Create Character";
        }

        public Character Character { get; set; }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            if (Character != null)
            {
                _Name.Text = Character.Name;
                _RaceCombo.SelectedText = Character.Race;
                _JobCombo.SelectedText = Character.Job;
                _Strength.Text = Character.Strength.ToString();
                _Intelligence.Text = Character.Intelligence.ToString();
                _Agility.Text = Character.Agility.ToString();
                _Constitution.Text = Character.Constitution.ToString();
                _Charisma.Text = Character.Charisma.ToString();
                
            }

            ValidateChildren();

        }

        private void OnCancel ( object sender, EventArgs e )
        {
            Close();
        }

        // The code below calls the character instance and allows the data to be accessed to be saved in the UI
        private void OnSave ( object sender, EventArgs e )
        {
            var button = sender as Button;
            if (button == null)
                return;

            var character = new Character();
            character.Name = _Name.Text;
            character.Race = _RaceCombo.SelectedText;
            character.Job = _JobCombo.SelectedText;

            character.Strength = ReadAsInt32(_Strength);
            character.Intelligence = ReadAsInt32(_Intelligence);
            character.Agility =  ReadAsInt32(_Agility);
            character.Constitution = ReadAsInt32(_Constitution);
            character.Charisma = ReadAsInt32(_Charisma);

            var error = character.Validate();
            if (!String.IsNullOrEmpty(error))
            {
                MessageBox.Show(this, error, "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }
            Close();
        }

        private int ReadAsInt32 ( Control control )
        {
            var text = control.Text;

            if (Int32.TryParse(text, out var result))
                return result;

            return -1;
        }

        private void OnValidateName ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;
            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "The Character Name is required");
                e.Cancel = true;
            }else
            {
                _errors.SetError(control, "");
            }
        }

        private void OnValidateStrength ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            var value = ReadAsInt32(control);
            if (value < 1)
            {
                _errors.SetError(control, "Strength is the physical power of your character. It must be greater  0");
            }else if (value > 100)
            {
                _errors.SetError(control, "Strength is the physical power of your character. It cannot surpass 100");
            }else 
            {
                _errors.SetError(control, "");
            }

        }

        private void OnValidateIntelligence ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            var value = ReadAsInt32(control);
            if (value < 1)
            {
                _errors.SetError(control, "Intelligence is the magical power of your character. It must be greater  0");
            }else if (value > 100)
            {
                _errors.SetError(control, "Intelligence is the magical power of your character. It cannot surpass  100");
            }
            else
            {
                _errors.SetError(control, "");
            }
        }

        private void OnValidateAgility ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            var value = ReadAsInt32(control);
            if (value < 1)
            {
                _errors.SetError(control, "Agility is your character's speed. It must be greater  0");
            } else if (value > 100)
            {
                _errors.SetError(control, "Agility is your character's speed. It cannot surpass  100");
            } else
            {

                _errors.SetError(control, "");
            }
            
        }

        private void OnValidateConstitution ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            var value = ReadAsInt32(control);
            if (value < 1)
            {
                _errors.SetError(control, "Constitution is your character's stamina. It must be greater  0");
            }else if (value > 100)
            {
                _errors.SetError(control, "Constitution is your character's stamina. It cannot surpass  100");
            }
            else
            {
                _errors.SetError(control, "");
            }

        }

        private void OnValidateCharisma ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            var value = ReadAsInt32(control);
            if (value < 1) 
            {
                _errors.SetError(control, "Charisma is your character's leadership. It must be greater  0");
            }else if (value > 100)
            {
                _errors.SetError(control, "Charisma is your character's leadership. It cannot surpass  100");
            }
            else
            {
                _errors.SetError(control, "");
            }
        }

        private void OnCharacterRace ( object sender, CancelEventArgs e )
        {
            var control = sender as ComboBox;

            if (_RaceCombo.SelectedIndex == -1)
            {
                _errors.SetError(control, "Choose a race for your character.");
            }else
            {
                _errors.SetError(control, "");
            }
            

        }

        private void OnCharacterJob ( object sender, CancelEventArgs e )
        {
            var control = sender as ComboBox;
            if (_JobCombo.SelectedIndex == -1)
            {
                _errors.SetError(control, "Your character's Job will determine their abilities learned. Please select a Job.");
            }
            else
            {
                _errors.SetError(control, "");
            }
        }

    }
}
