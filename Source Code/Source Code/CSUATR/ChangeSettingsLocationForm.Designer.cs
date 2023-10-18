namespace CSUATR
{
    partial class ChangeSettingsLocationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
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
        private void InitializeComponent()
        {
            this.labelFoldername = new System.Windows.Forms.Label();
            this.labelFilename = new System.Windows.Forms.Label();
            this.labelNote = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxFile = new System.Windows.Forms.ComboBox();
            this.comboBoxFolder = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelFoldername
            // 
            this.labelFoldername.AutoSize = true;
            this.labelFoldername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFoldername.Location = new System.Drawing.Point(10, 46);
            this.labelFoldername.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelFoldername.Name = "labelFoldername";
            this.labelFoldername.Size = new System.Drawing.Size(78, 13);
            this.labelFoldername.TabIndex = 0;
            this.labelFoldername.Text = "Folder Name";
            // 
            // labelFilename
            // 
            this.labelFilename.AutoSize = true;
            this.labelFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFilename.Location = new System.Drawing.Point(25, 72);
            this.labelFilename.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelFilename.Name = "labelFilename";
            this.labelFilename.Size = new System.Drawing.Size(63, 13);
            this.labelFilename.TabIndex = 1;
            this.labelFilename.Text = "File Name";
            // 
            // labelNote
            // 
            this.labelNote.AutoSize = true;
            this.labelNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNote.Location = new System.Drawing.Point(10, 9);
            this.labelNote.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelNote.Name = "labelNote";
            this.labelNote.Size = new System.Drawing.Size(246, 26);
            this.labelNote.TabIndex = 3;
            this.labelNote.Text = "Note: All folders and files are confined to the same\r\n          folder which cont" +
    "ains this project executable\r\n";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(92, 95);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(65, 23);
            this.buttonOk.TabIndex = 5;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(163, 95);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(65, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // comboBoxFile
            // 
            this.comboBoxFile.FormattingEnabled = true;
            this.comboBoxFile.Location = new System.Drawing.Point(92, 69);
            this.comboBoxFile.Name = "comboBoxFile";
            this.comboBoxFile.Size = new System.Drawing.Size(136, 21);
            this.comboBoxFile.TabIndex = 7;
            this.comboBoxFile.SelectedIndexChanged += new System.EventHandler(this.comboBoxFile_SelectedIndexChanged);
            // 
            // comboBoxFolder
            // 
            this.comboBoxFolder.FormattingEnabled = true;
            this.comboBoxFolder.Location = new System.Drawing.Point(92, 43);
            this.comboBoxFolder.Name = "comboBoxFolder";
            this.comboBoxFolder.Size = new System.Drawing.Size(136, 21);
            this.comboBoxFolder.TabIndex = 8;
            this.comboBoxFolder.SelectedIndexChanged += new System.EventHandler(this.comboBoxFolder_SelectedIndexChanged);
            // 
            // ChangeSettingsLocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 126);
            this.Controls.Add(this.comboBoxFolder);
            this.Controls.Add(this.comboBoxFile);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelNote);
            this.Controls.Add(this.labelFilename);
            this.Controls.Add(this.labelFoldername);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximumSize = new System.Drawing.Size(276, 165);
            this.MinimumSize = new System.Drawing.Size(276, 165);
            this.Name = "ChangeSettingsLocationForm";
            this.Text = "Change Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFoldername;
        private System.Windows.Forms.Label labelFilename;
        private System.Windows.Forms.Label labelNote;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxFile;
        private System.Windows.Forms.ComboBox comboBoxFolder;
    }
}