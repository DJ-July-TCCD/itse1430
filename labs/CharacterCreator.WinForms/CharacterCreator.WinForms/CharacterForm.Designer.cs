namespace CharacterCreator.WinForms
{
    partial class CharacterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this._Name = new System.Windows.Forms.TextBox();
            this._Intelligence = new System.Windows.Forms.TextBox();
            this._Strength = new System.Windows.Forms.TextBox();
            this._Agility = new System.Windows.Forms.TextBox();
            this._Constitution = new System.Windows.Forms.TextBox();
            this._Charisma = new System.Windows.Forms.TextBox();
            this._RaceCombo = new System.Windows.Forms.ComboBox();
            this._JobCombo = new System.Windows.Forms.ComboBox();
            this._BtnSave = new System.Windows.Forms.Button();
            this._BtnCancel = new System.Windows.Forms.Button();
            this._errors = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._errors)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chracter Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Race";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Job";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Stength";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Intelligence";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Agility";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 254);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Constitution";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 291);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "Charisma";
            // 
            // _Name
            // 
            this._Name.Location = new System.Drawing.Point(155, 26);
            this._Name.Name = "_Name";
            this._Name.Size = new System.Drawing.Size(216, 27);
            this._Name.TabIndex = 0;
            this._Name.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateName);
            // 
            // _Intelligence
            // 
            this._Intelligence.Location = new System.Drawing.Point(155, 174);
            this._Intelligence.Name = "_Intelligence";
            this._Intelligence.Size = new System.Drawing.Size(96, 27);
            this._Intelligence.TabIndex = 4;
            this._Intelligence.Text = "50";
            this._Intelligence.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateIntelligence);
            // 
            // _Strength
            // 
            this._Strength.Location = new System.Drawing.Point(155, 140);
            this._Strength.Name = "_Strength";
            this._Strength.Size = new System.Drawing.Size(96, 27);
            this._Strength.TabIndex = 3;
            this._Strength.Text = "50";
            this._Strength.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateStrength);
            // 
            // _Agility
            // 
            this._Agility.Location = new System.Drawing.Point(155, 215);
            this._Agility.Name = "_Agility";
            this._Agility.Size = new System.Drawing.Size(96, 27);
            this._Agility.TabIndex = 5;
            this._Agility.Text = "50";
            this._Agility.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateAgility);
            // 
            // _Constitution
            // 
            this._Constitution.Location = new System.Drawing.Point(155, 251);
            this._Constitution.Name = "_Constitution";
            this._Constitution.Size = new System.Drawing.Size(96, 27);
            this._Constitution.TabIndex = 6;
            this._Constitution.Text = "50";
            this._Constitution.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateConstitution);
            // 
            // _Charisma
            // 
            this._Charisma.Location = new System.Drawing.Point(155, 288);
            this._Charisma.Name = "_Charisma";
            this._Charisma.Size = new System.Drawing.Size(96, 27);
            this._Charisma.TabIndex = 7;
            this._Charisma.Text = "50";
            this._Charisma.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateCharisma);
            // 
            // _RaceCombo
            // 
            this._RaceCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._RaceCombo.FormattingEnabled = true;
            this._RaceCombo.Items.AddRange(new object[] {
            "Human",
            "Elf",
            "Dwarf",
            "Dragon-Kin",
            "Beastmen"});
            this._RaceCombo.Location = new System.Drawing.Point(155, 62);
            this._RaceCombo.Name = "_RaceCombo";
            this._RaceCombo.Size = new System.Drawing.Size(151, 28);
            this._RaceCombo.TabIndex = 1;
            this._RaceCombo.Validating += new System.ComponentModel.CancelEventHandler(this.OnCharacterRace);
            // 
            // _JobCombo
            // 
            this._JobCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._JobCombo.FormattingEnabled = true;
            this._JobCombo.Items.AddRange(new object[] {
            "Fighter",
            "Bard",
            "Priest",
            "Warlock",
            "Assassin"});
            this._JobCombo.Location = new System.Drawing.Point(155, 103);
            this._JobCombo.Name = "_JobCombo";
            this._JobCombo.Size = new System.Drawing.Size(151, 28);
            this._JobCombo.TabIndex = 2;
            this._JobCombo.Validating += new System.ComponentModel.CancelEventHandler(this.OnCharacterJob);
            // 
            // _BtnSave
            // 
            this._BtnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._BtnSave.Location = new System.Drawing.Point(302, 372);
            this._BtnSave.Name = "_BtnSave";
            this._BtnSave.Size = new System.Drawing.Size(94, 29);
            this._BtnSave.TabIndex = 8;
            this._BtnSave.Text = "Save";
            this._BtnSave.UseVisualStyleBackColor = true;
            // 
            // _BtnCancel
            // 
            this._BtnCancel.CausesValidation = false;
            this._BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._BtnCancel.Location = new System.Drawing.Point(418, 372);
            this._BtnCancel.Name = "_BtnCancel";
            this._BtnCancel.Size = new System.Drawing.Size(94, 29);
            this._BtnCancel.TabIndex = 9;
            this._BtnCancel.Text = "Cancel";
            this._BtnCancel.UseVisualStyleBackColor = true;
            // 
            // _errors
            // 
            this._errors.ContainerControl = this;
            // 
            // CharacterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this._BtnCancel;
            this.ClientSize = new System.Drawing.Size(578, 454);
            this.Controls.Add(this._BtnCancel);
            this.Controls.Add(this._BtnSave);
            this.Controls.Add(this._JobCombo);
            this.Controls.Add(this._RaceCombo);
            this.Controls.Add(this._Charisma);
            this.Controls.Add(this._Constitution);
            this.Controls.Add(this._Agility);
            this.Controls.Add(this._Strength);
            this.Controls.Add(this._Intelligence);
            this.Controls.Add(this._Name);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(596, 501);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(596, 501);
            this.Name = "CharacterForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Character";
            ((System.ComponentModel.ISupportInitialize)(this._errors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _Name;
        private System.Windows.Forms.TextBox _Intelligence;
        private System.Windows.Forms.TextBox _Strength;
        private System.Windows.Forms.TextBox _Agility;
        private System.Windows.Forms.TextBox _Constitution;
        private System.Windows.Forms.TextBox _Charisma;
        private System.Windows.Forms.ComboBox _RaceCombo;
        private System.Windows.Forms.ComboBox _JobCombo;
        private System.Windows.Forms.Button _BtnSave;
        private System.Windows.Forms.Button _BtnCancel;
        private System.Windows.Forms.ErrorProvider _errors;
        private System.Windows.Forms.Button OnSave_Click;
        private System.Windows.Forms.Button OnCancel_Click;
    }
}